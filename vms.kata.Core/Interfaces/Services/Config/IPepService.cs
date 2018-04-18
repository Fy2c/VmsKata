namespace vms.kata.Domain.Interfaces.Services.Config
{
    public interface IPepService
    {
        bool PropertyFoundForUser(string pageName, string elementName, string propertyName, string user);
    }
}
