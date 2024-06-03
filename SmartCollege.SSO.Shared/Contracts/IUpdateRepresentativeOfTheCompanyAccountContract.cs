namespace SmartCollege.SSO.Shared.Contracts
{
    public interface IUpdateRepresentativeOfTheCompanyAccountContract
    {
        string Email { get; set; }

        string FullName { get; set; }

        string Phone { get; set; }

        string Company { get; set; }
    }
}
