using System;
using System.Collections.Generic;
using System.Linq;
using vms.kata.Domain.Interfaces.Services.Config;

namespace vms.kata.Tests.Config
{
    public class FakeMppProperty
    {
        public string moduleCode;
        public string processName;
        public string propertyName;
        public string companyCode;
        public string value;
    }

    public class MockMppService : IMppService
    {
        ICollection<FakeMppProperty> fakeDataSource;
        public MockMppService(ICollection<FakeMppProperty> fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

            public string GetPropertyForCompany(string moduleCode, string processName, string propertyName, string companyCode)
            {
                return (from mppRow in fakeDataSource
                        where mppRow.moduleCode.Equals(moduleCode, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.processName.Equals(processName, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.propertyName.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.companyCode.Equals(companyCode, StringComparison.CurrentCultureIgnoreCase)
                        select mppRow.value).FirstOrDefault();
            }

            public bool PropertyFoundForCompany(string moduleCode, string processName, string propertyName, string companyCode)
            {
                return (from mppRow in fakeDataSource
                        where mppRow.moduleCode.Equals(moduleCode, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.processName.Equals(processName, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.propertyName.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase)
                            && mppRow.companyCode.Equals(companyCode, StringComparison.CurrentCultureIgnoreCase)
                        select mppRow).Any();
            }
    }
}
