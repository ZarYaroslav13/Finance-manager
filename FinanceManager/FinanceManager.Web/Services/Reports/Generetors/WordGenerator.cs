using Azure;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FinanceManager.Application.Models;
using FinanceManager.Domain.Services.CurrentUserService;
using FinanceManager.Domain.Wrapper;
using FinanceManager.Infrastructure.Models;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace FinanceManager.Web.Services.Reports.Generators;

public class WordGenerator : ReportGeneretor
{
    public WordGenerator(IWebHostEnvironment hostEnvironment, ICurrentUserService currentUserService, IStringLocalizer<ReportGeneretor> localizer) : base(hostEnvironment, currentUserService, localizer)
    {
    }

    public override FileType GeneretorFileType => FileType.Word;

    protected override async Task<Domain.Wrapper.IResult> GenerateFileReport(FinanceReportDTO report, string reportPath)
    {
        try
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(reportPath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                mainPart.Document = new(new Body());

                ConstructWordReport(mainPart, report);

                mainPart.Document.Save();
            }

            return await Result.SuccessAsync("Word report created successfully");
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    private void ConstructWordReport(MainDocumentPart mainPart, FinanceReportDTO report)
    {
        int sizeOfSeparator = 40;

        AddWalletPart(mainPart, report);

        AddHorizontalLine(mainPart.Document.Body, BorderValues.Double, sizeOfSeparator);

        AddDetailedInfoPart(mainPart, report);
    }

    private void AddWalletPart(MainDocumentPart mainPart, FinanceReportDTO report)
    {
        var body = mainPart.Document.Body;
        AddHeading(body, _localizer["Report for Wallet: "] + report.WalletName, "48");
        AddHorizontalLine(body, BorderValues.Single, space: 1);

        AddParagraph(body, _localizer["Wallet Name: "] + report.WalletName);
        AddParagraph(body, _localizer["Balance: "] + report.Balance);
        AddParagraph(body, _localizer["Total Income: "] + report.TotalIncome);
        AddParagraph(body, _localizer["Total Expense: "] + report.TotalExpense);
        AddParagraph(body, _localizer["Period: "] + $"{report.Period.StartDate.ToShortDateString()} - {report.Period.EndDate.ToShortDateString()}");
    }

    private void AddDetailedInfoPart(MainDocumentPart mainPart, FinanceReportDTO report)
    {
        var body = mainPart.Document.Body;

        AddHeading(body, _localizer["Operations"]);

        AddOperationsTable(body, report);

        AddHorizontalLine(body, BorderValues.Single, space: 1);

        AddHeading(body, _localizer["Charts"]);

        AddCharts(mainPart, report);
    }

    private void AddOperationsTable(Body body, FinanceReportDTO report)
    {
        var table = new Table();

        var props = new TableProperties(new TableBorders(
            new TopBorder { Val = BorderValues.Single, Size = 6 },
            new BottomBorder { Val = BorderValues.Single, Size = 6 },
            new LeftBorder { Val = BorderValues.Single, Size = 6 },
            new RightBorder { Val = BorderValues.Single, Size = 6 },
            new InsideHorizontalBorder { Val = BorderValues.Single, Size = 6 },
            new InsideVerticalBorder { Val = BorderValues.Single, Size = 6 }
        ));
        table.AppendChild(props);

        table.AppendChild(new TableRow(new[]
        {
        CreateCell(_localizer["Name"]),
        CreateCell(_localizer["Profit"]),
        CreateCell(_localizer["Amount"]),
        CreateCell(_localizer["Date"])
    }));

        foreach (var op in report.Operations)
        {
            var isProfit = op.Type.EntryType == EntryType.Income;
            var sign = isProfit ? "+" : "-";

            table.AppendChild(new TableRow(new[]
            {
            CreateCell(op.Type.Name),
            CreateCell(isProfit ? _localizer["Yes"] : _localizer["No"]),
            CreateCell($"{sign}{op.Amount}"),
            CreateCell(op.Date.ToShortDateString())
        }));
        }

        body.AppendChild(table);
    }

    private void AddCharts(MainDocumentPart mainPart, FinanceReportDTO report)
    {
        AddBarChart(mainPart, report);
    }

    private void AddHeading(Body body, string text, string fontSize = "32") =>
    body.AppendChild(
        new Paragraph(
            new Run(
                new Text(text)) 
            { 
                RunProperties = new RunProperties(
                    new Bold(), 
                    new FontSize() { Val= fontSize }) 
            }
        ));

    private void AddParagraph(Body body, string text, string fontSize = "28") =>
        body.AppendChild(
            new Paragraph(
                new Run(
                    new Text(text))
                {
                    RunProperties = new RunProperties(
                        new FontSize() { Val = fontSize})
                }));

    private void AddHorizontalLine(
        Body body,
        BorderValues borderType,
        int size = 20,
        int space = 10,
        string color = "auto")
    {
        var paragraph = new Paragraph(
            new ParagraphProperties(
                new ParagraphBorders(
                    new BottomBorder
                    {
                        Val = borderType,
                        Color = color,
                        Size = (uint)size,
                        Space = (uint)space
                    }
                )
            )
        );

        body.AppendChild(paragraph);
    }

    private TableCell CreateCell(string text) =>
        new TableCell(
            new Paragraph(
                new Run(
                    new Text(text)))
            {
                ParagraphProperties = new()
                {
                    Justification = new() { Val = JustificationValues.Center}
                }
            });

    public void AddBarChart(MainDocumentPart mainPart, FinanceReportDTO report)
    {
        var chartPart = mainPart.AddNewPart<ChartPart>();
        var body = mainPart.Document.Body;

        // Chart space and chart
        chartPart.ChartSpace = new ChartSpace(new EditingLanguage { Val = CultureInfo.CurrentCulture.Name });
        var chart = new Chart();
        chartPart.ChartSpace.AppendChild(chart);

        var plotArea = new PlotArea();
        chart.AppendChild(plotArea);

        var barChart = new BarChart(
            new BarDirection() { Val = BarDirectionValues.Column },
            new BarGrouping() { Val = BarGroupingValues.Clustered },
            new VaryColors() { Val = false }
        );

        var operations = report.Operations.OrderBy(op => op.Date).ToList();

        // Group income and expense into two series
        var incomeOps = operations.Where(o => o.Type.EntryType == EntryType.Income).ToList();
        var expenseOps = operations.Where(o => o.Type.EntryType == EntryType.Expense).ToList();

        AddSeries(barChart, incomeOps, "Income", "00B050");   // Green
        AddSeries(barChart, expenseOps, "Expense", "FF0000"); // Red

        // Add axis IDs
        barChart.Append(new AxisId() { Val = 48650112u });
        barChart.Append(new AxisId() { Val = 48672768u });

        plotArea.Append(barChart);

        // X Axis (Dates)
        plotArea.Append(new CategoryAxis(
            new AxisId() { Val = 48650112u },
            new Scaling(new Orientation() { Val = OrientationValues.MinMax }),
            new AxisPosition() { Val = AxisPositionValues.Bottom },
            new TickLabelPosition() { Val = TickLabelPositionValues.NextTo },
            new CrossingAxis() { Val = 48672768u },
            new Crosses() { Val = CrossesValues.AutoZero },
            new AutoLabeled() { Val = true },
            new LabelAlignment() { Val = LabelAlignmentValues.Center },
            new LabelOffset() { Val = 100 }
        ));

        // Y Axis (Money)
        plotArea.Append(new ValueAxis(
            new AxisId() { Val = 48672768u },
            new Scaling(new Orientation() { Val = OrientationValues.MinMax }),
            new AxisPosition() { Val = AxisPositionValues.Left },
            new MajorGridlines(),
            new DocumentFormat.OpenXml.Drawing.Charts.NumberingFormat() { FormatCode = "#,##0.00", SourceLinked = true },
            new TickLabelPosition() { Val = TickLabelPositionValues.NextTo },
            new CrossingAxis() { Val = 48650112u },
            new Crosses() { Val = CrossesValues.AutoZero },
            new CrossBetween() { Val = CrossBetweenValues.Between }
        ));

        // Add legend
        chart.Append(new Legend(
            new LegendPosition() { Val = LegendPositionValues.Right },
            new Layout()
        ));

        // Add title
        chart.Append(new Title(
            new ChartText(
                new RichText(
                    new DocumentFormat.OpenXml.Drawing.BodyProperties(),
                    new DocumentFormat.OpenXml.Drawing.ListStyle(),
                    new DocumentFormat.OpenXml.Drawing.Paragraph(
                        new DocumentFormat.OpenXml.Drawing.Run(
                            new DocumentFormat.OpenXml.Drawing.Text(_localizer["Operation History Chart"])
                        )
                    )
                )
            ),
            new Overlay() { Val = false }
        ));

        chartPart.ChartSpace.Save();

        // Embed the chart into the document
        string relId = mainPart.GetIdOfPart(chartPart);
        var drawing = new Drawing(
            new Inline(
                new Extent() { Cx = 5486400, Cy = 3200400 },
                new EffectExtent { LeftEdge = 0L, TopEdge = 0L, RightEdge = 0L, BottomEdge = 0L },
                new DocProperties() { Id = 1u, Name = _localizer["Operation Chart"].Value },
                new NonVisualGraphicFrameDrawingProperties(),
                new DocumentFormat.OpenXml.Drawing.Graphic(
                    new DocumentFormat.OpenXml.Drawing.GraphicData(
                        new ChartReference() { Id = relId }
                    )
                    { Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart" }
                )
            )
        );

        body.AppendChild(new Paragraph(new Run(drawing)));
    }

    void AddSeries(BarChart barChart, List<FinanceOperationDTO> ops, string label, string colorHex)
    {
        var series = new BarChartSeries(
            new DocumentFormat.OpenXml.Drawing.Charts.Index() { Val = (uint)barChart.Elements<BarChartSeries>().Count() },
            new Order() { Val = (uint)barChart.Elements<BarChartSeries>().Count() },
            new SeriesText(new NumericValue() { Text = label })
        );

        var categoryAxis = new StringLiteral(new PointCount() { Val = (uint)ops.Count });
        var valueAxis = new NumberLiteral(new FormatCode("General"), new PointCount() { Val = (uint)ops.Count });

        for (int i = 0; i < ops.Count; i++)
        {
            var op = ops[i];
            categoryAxis.Append(new StringPoint() { Index = (uint)i, NumericValue = new NumericValue(op.Date.ToShortDateString()) });
            valueAxis.Append(new NumericPoint() { Index = (uint)i, NumericValue = new NumericValue(op.Amount.ToString()) });

            var dataPoint = new DataPoint(
                new DocumentFormat.OpenXml.Drawing.Charts.Index() { Val = (uint)i },
                new ChartShapeProperties(
                    new DocumentFormat.OpenXml.Drawing.SolidFill(
                        new DocumentFormat.OpenXml.Drawing.RgbColorModelHex() { Val = colorHex }
                    )
                )
            );

            series.Append(dataPoint);
        }

        series.Append(new CategoryAxisData(categoryAxis));
        series.Append(new Values(valueAxis));

        barChart.Append(series);
    }

}
