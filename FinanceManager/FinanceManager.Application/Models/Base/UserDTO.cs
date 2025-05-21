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

    public List<string> Roles
    {
        get { return _roles; }
        set { _roles = value; }
    }

    private string _lastName = string.Empty;
    private string _firstName = string.Empty;
    private string _email = string.Empty;
    private List<string> _roles;

    public override bool Equals(object? obj)
    {
        if (!base.Equals(obj))
            return false;

        UserDTO user = (UserDTO)obj;

        return _firstName == user.FirstName
               && _lastName == user.LastName
               && _email == user.Email
               && AreEqualLists(_roles, user._roles);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _firstName, _lastName, _email, GetHashCodeOfList(_roles));
    }
}
