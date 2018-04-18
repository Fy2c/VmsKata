using System;
using System.Collections.Generic;
using System.Linq;
using vms.kata.Domain.Interfaces.Services.Config;

namespace vms.kata.Tests.Config
{
    public class FakePepProperty
    {
        public string pageName;
        public string elementName;
        public string propertyName;
        public string companyCode;
        public string value;
        public string userId;
    }

    public class MockPepService : IPepService
    {
        ICollection<FakePepProperty> fakeDataSource;

        public MockPepService(ICollection<FakePepProperty> fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

        public bool PropertyFoundForUser(string pageName, string elementName, string propertyName, string userId)
        {
            return (from row in fakeDataSource
                    where row.pageName.Equals(pageName, StringComparison.CurrentCultureIgnoreCase)
                        && row.elementName.Equals(elementName, StringComparison.CurrentCultureIgnoreCase)
                        && row.propertyName.Equals(propertyName, StringComparison.CurrentCultureIgnoreCase)
                        && row.userId.Equals(userId, StringComparison.CurrentCultureIgnoreCase)
                    select row.value).Any();
        }
    }
}
