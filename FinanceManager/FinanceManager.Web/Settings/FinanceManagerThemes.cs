using MudBlazor;

namespace FinanceManager.Web.Settings;

public class FinanceManagerThemes
{
    private static Typography DefaultTypography = new()

    {
        Default = new DefaultTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },

        H1 = new H1Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "6rem",
            FontWeight = "300",
            LineHeight = "1.167",
            LetterSpacing = "-.01562em"
        },

        H2 = new H2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "3.75rem",
            FontWeight = "300",
            LineHeight = "1.2",
            LetterSpacing = "-.00833em"
        },

        H3 = new H3Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "3rem",
            FontWeight = "400",
            LineHeight = "1.167",
            LetterSpacing = "0"
        },

        H4 = new H4Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "2.125rem",
            FontWeight = "400",
            LineHeight = "1.235",
            LetterSpacing = ".00735em"
        },

        H5 = new H5Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1.5rem",
            FontWeight = "400",
            LineHeight = "1.334",
            LetterSpacing = "0"
        },

        H6 = new H6Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1.25rem",
            FontWeight = "400",
            LineHeight = "1.6",
            LetterSpacing = ".0075em"
        },

        Button = new ButtonTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.75",
            LetterSpacing = ".02857em"
        },

        Body1 = new Body1Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = "1rem",
            FontWeight = "400",
            LineHeight = "1.5",
            LetterSpacing = ".00938em"
        },

        Body2 = new Body2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "400",
            LineHeight = "1.43",
            LetterSpacing = ".01071em"
        },

        Caption = new CaptionTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".75rem",
            FontWeight = "400",
            LineHeight = "1.66",
            LetterSpacing = ".03333em"
        },

        Subtitle1 = new Subtitle1Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.57",
            LetterSpacing = ".00714em"
        },

        Subtitle2 = new Subtitle2Typography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".875rem",
            FontWeight = "500",
            LineHeight = "1.57",
            LetterSpacing = ".00714em"
        },

        Overline = new OverlineTypography()
        {
            FontFamily = new[] { "Montserrat", "Helvetica", "Arial", "sans-serif" },
            FontSize = ".75rem",
            FontWeight = "400",
            LineHeight = "2.66",
            LetterSpacing = ".08333em"
        }
    };

    private static LayoutProperties DefaultLayoutProperties = new LayoutProperties()
    {
        DefaultBorderRadius = "3px"
    };

    public static MudTheme DefaultTheme = new MudTheme()
    {
        PaletteLight = new()
        {
            Primary = "#1E88E5",
            Background = Colors.Gray.Lighten5,
            DrawerBackground = "#FFF",
            DrawerText = "rgba(0,0,0, 0.7)",
            Success = "#007E33"
        },
        Typography = DefaultTypography,
        LayoutProperties = DefaultLayoutProperties
    };

    public static MudTheme DarkTheme = new MudTheme()
    {
        PaletteDark = new()
        {
            Black = "#27272f",
            Background = "#121212",
            Surface = "#1E1E2F",
            DrawerBackground = "#1E1E2F",
            DrawerText = "#ffffffb3",
            AppbarBackground = "#1E1E2F",
            AppbarText = "#ffffff",
            Primary = "#90CAF9",
            Secondary = "#F48FB1",
            Tertiary = "#CE93D8",
            Success = "#66BB6A",
            Warning = "#FFA726",
            Error = "#EF5350",
            Info = "#29B6F6",
            TextPrimary = "#ffffff",
            TextSecondary = "#ffffffb3",
            ActionDefault = "#adadb1",
            ActionDisabled = "#6b6b6b",
            ActionDisabledBackground = "#3c3c3c",
            Divider = "#373737",
            DividerLight = "#474747",
            LinesDefault = "#2a2a2a",
            LinesInputs = "#3c3c3c",
            TableLines = "#3a3a3a",
            OverlayDark = "rgba(33,33,33,0.8)"
        },
        Typography = DefaultTypography,
        LayoutProperties = DefaultLayoutProperties
    };
}
