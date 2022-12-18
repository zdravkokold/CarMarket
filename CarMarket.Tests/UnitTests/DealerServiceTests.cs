using CarMarket.Services.Data.Entities;
using CarMarket.Services.Dealers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Tests.UnitTests
{
    [TestFixture]
    public class DealerServiceTests : UnitTestsBase
    {
        private IDealerService dealerService;
        private UserManager<ApplicationUser> userManager;
               

        [OneTimeSetUp]
        public void SetUp() => dealerService = new DealerService(data, userManager); 

        [Test]
        public void GetDealerId_ShouldReturnCorrectUserId()
        {
            var resultId = dealerService.GetDealerId(Dealer.UserId);
            Assert.AreEqual(Dealer.Id, resultId);        
        }

        [Test]
        public void UserWithPhoneNumber_ShouldWork()
        {
            bool result = dealerService.UserWithPhoneNumberExists("0878980000");
            Assert.IsTrue(result);

            bool result2 = dealerService.UserWithPhoneNumberExists("888");
            Assert.IsFalse(result2);
        }

        [Test]
        public void UserHasRents_ShouldWork()
        {
            bool result = dealerService.UserHasCars(Owner.Id);
            Assert.IsTrue(result);

            bool result2 = dealerService.UserHasCars(Owner.Id + 3);
            Assert.IsFalse(result2);
        }

        [Test]
        public void ExistsById_ShouldWork()
        {
            bool result = dealerService.ExistsById("TestUserId");
            Assert.IsTrue(result);

            bool result2 = dealerService.UserHasCars("");
            Assert.IsFalse(result2);
        }
    }
}
