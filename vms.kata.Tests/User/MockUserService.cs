using System;
using System.Collections.Generic;
using System.Linq;
using vms.kata.Domain.Interfaces.Services.User;

namespace vms.kata.Tests.User
{
    public class FakeUserInfo
    {
        public string userId;
        public string workId;
    }

    public class MockUserService : IUserService
    {
        ICollection<FakeUserInfo> fakeDataSource;
        public MockUserService(ICollection<FakeUserInfo> fakeDataSource)
        {
            this.fakeDataSource = fakeDataSource;
        }

        public string GetWorkId(string userId)
        {
            return (from userInfo in fakeDataSource
                    where userInfo.userId.Equals(userId, StringComparison.CurrentCultureIgnoreCase)
                    select userInfo.workId).FirstOrDefault();
        }
    }
}
