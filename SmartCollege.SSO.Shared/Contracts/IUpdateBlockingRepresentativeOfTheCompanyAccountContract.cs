namespace SmartCollege.SSO.Shared.Contracts
{
    public interface IUpdateBlockingRepresentativeOfTheCompanyAccountContract
    {
        string Email { get; set; }

        bool IsBlocked { get; set; }
    }
}
