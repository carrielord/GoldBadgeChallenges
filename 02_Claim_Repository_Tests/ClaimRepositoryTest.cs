using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Claim_Repository_Tests
{
    [TestClass]
    public class ClaimRepositoryTest
    {
        private ClaimRepository _claimRepository;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepository = new ClaimRepository();
            _claim = new Claim(837264, TypeOfClaim.Car, "wrecked" ,2949.98m, new DateTime(2019, 6, 8), new DateTime(2019, 6, 10));
            _claimRepository.AddClaim(_claim);
        }

        [TestMethod]
        public void SeeNextClaimTest()
        {
            Claim claim = _claimRepository.SeeNextClaim();
            Assert.AreEqual(claim, _claim);
        }

        [TestMethod]
        public void DealWithClaimTest()
        {
            int initialCount = _claimRepository.ViewClaimQueue().Count;
            _claimRepository.DealWithClaim();
            bool dealtWith = (_claimRepository.ViewClaimQueue().Count <= initialCount);
            Assert.IsTrue(dealtWith);
        }
        [TestMethod]
        public void AddNewClaimTest()
        {
            int expected = 2;
            Claim claim = new Claim(734628, TypeOfClaim.Home, "roof", 8375.88m, new DateTime(2018, 12, 19), new DateTime(2019, 1, 18));
            _claimRepository.AddClaim(claim);
            Assert.AreEqual(expected, _claimRepository.ViewClaimQueue().Count);
        }
    }
}
