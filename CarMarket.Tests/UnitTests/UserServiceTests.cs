using CarMarket.Services.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Tests.UnitTests
{
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void SetUp() => userService = new UserService(data);

        [Test]
        public void All_ShouldReturn_AllUsersAndDealers()
        {
            var result = userService.All();
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }
    }
}
