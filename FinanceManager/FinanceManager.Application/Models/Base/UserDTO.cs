namespace FinanceManager.Application.Models.Base;

public class UserDTO : ModelDTO
{
    public string LastName
    {
        get { return _lastName; }
        set { _lastName = value.Trim(); }
    }

    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value.Trim(); }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value.Trim(); }
    }

    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _email = string.Empty;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        UserDTO human = (UserDTO)obj;

        return _firstName == human.FirstName
               && _lastName == human.LastName
               && _email == human.Email;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _firstName, _lastName, _email);
    }
}
