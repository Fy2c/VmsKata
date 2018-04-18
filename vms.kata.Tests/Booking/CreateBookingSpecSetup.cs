using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using vms.kata.Application.Services;
using vms.kata.Tests.Config;
using vms.kata.Tests.User;

namespace vms.kata.Tests.BookingSpec
{
    public class CreateBookingSpecSetup : BaseBookingSpec
    {
        [TestInitialize]
        public void SetupTest()
        {
            List<FakeMppProperty> fakeMppDatasource = new List<FakeMppProperty>()
            {
                new FakeMppProperty { moduleCode = "book", processName = "BookingKeyGlossaryDefaultWorkID", propertyName = "term", value = "DDP", companyCode = "957"},
                new FakeMppProperty { moduleCode = "book", processName = "VOBCarrierRelease", propertyName = "Hidden", companyCode = "957"}
            };

            List<FakePepProperty> fakePepDatasource = new List<FakePepProperty>()
            {
                new FakePepProperty { pageName = "BookingManagementTab.aspx", elementName = "OriginCreateBooking", propertyName = "UseOfficeCode", userId = "JohnDoe" }
            };

            List<FakeUserInfo> fakeUserDatasource = new List<FakeUserInfo>()
            {
                new FakeUserInfo { workId = "HK0", userId = "JohnDoe" }
            };

            List<FakeConfigProperty> fakeConfigDatasource = new List<FakeConfigProperty>()
            {
                new FakeConfigProperty { variableId = "LAST_BOOKING_KEYPASISF", value1 = "1", machineCode = "G" },
                new FakeConfigProperty { variableId = "LAST_BOOKING_KEYPASHK0", value1 = "1", machineCode = "G" },
                new FakeConfigProperty { variableId = "LAST_BOOKING_KEYPASSH0", value1 = "1", machineCode = "G" },
                new FakeConfigProperty { variableId = "LAST_BOOKING_KEYPASDDP", value1 = "1", machineCode = "G" }
            };

            MockMppService mockMppService = new MockMppService(fakeMppDatasource);
            MockPepService mockPepService = new MockPepService(fakePepDatasource);
            MockUserService mockUserService = new MockUserService(fakeUserDatasource);
            MokeConfigService fakeConfigService = new MokeConfigService(fakeConfigDatasource);

            bookingService = new BookingService(mockMppService, mockPepService, mockUserService, fakeConfigService);
        }        
    }

    
}
