namespace vms.kata.Domain.Interfaces.Services.Config
{
    public interface IConfigService
    {
        string GetDbConfig(string varibableId, int valueFieldNumber, int? valuePadding, bool? useMachineCode);
    }
}
