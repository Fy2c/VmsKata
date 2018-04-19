using System;
using System.Collections.Generic;
using System.Linq;
using vms.kata.Domain.Interfaces.Services.Config;

namespace vms.kata.Tests.Config
{
    public class FakeConfigProperty
    {
        public string value1;
        public string value2;
        public string value3;
        public string machineCode;
        public string variableId;
    }

    public class MockConfigService : IConfigService
    {
        private ICollection<FakeConfigProperty> fakeDatasource;

        public MockConfigService(ICollection<FakeConfigProperty> fakeDatasource)
        {
            this.fakeDatasource = fakeDatasource;
        }

        public string GetDbConfig(string varibableId, int valueFieldNumber, int? valuePadding, bool? useMachineCode = false)
        {
            var configResult = (from config in fakeDatasource
                                where varibableId.Equals(config.variableId, StringComparison.CurrentCultureIgnoreCase)
                                select new
                                {
                                    config.machineCode,
                                    value = (valueFieldNumber == 1 ? config.value1 :
                                             valueFieldNumber == 2 ? config.value2 :
                                             valueFieldNumber == 3 ? config.value3 :
                                             throw new NotImplementedException())
                                }).First();
            var result = configResult.value;

            if (valuePadding != null) {
                result = result.PadLeft((int)valuePadding, '0');
                result = result.Substring(result.Length - ((int) valuePadding - 1), (int) valuePadding - 1);
            }
            
            if (useMachineCode == true)
            {
                result = configResult.machineCode + result;
            }

            return result;
        }
    }
}
