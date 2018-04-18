namespace vms.kata.Domain.Interfaces.Services.Config
{
    public interface IMppService
    {
        bool PropertyFoundForCompany(string moduleCode, string processName, string propertyName, string companyCode);
        string GetPropertyForCompany(string moduleCode, string processName, string propertyName, string companyCode);
    }
}
