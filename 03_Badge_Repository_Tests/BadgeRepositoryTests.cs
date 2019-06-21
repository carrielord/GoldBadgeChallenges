using System;
using System.Collections.Generic;
using _03_Komodo_Badge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badge_Repository_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private Badge _badge;
        private BadgeRepository _badgeRepository;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepository = new BadgeRepository();
            List<string> doorNameOne = new List<string> ();
            doorNameOne.Add("A1");
            doorNameOne.Add("A2");
            doorNameOne.Add("A3");
            _badge = new Badge(12345, doorNameOne);
            _badgeRepository.CreateNewBadge(12345, doorNameOne);
        }

        [TestMethod]
        public void CreateNewBadgeTest()
        {
            int expected = 2;
            List<string> doorNamesTwo = new List<string>();
            doorNamesTwo.Add("B1");
            doorNamesTwo.Add("B6");
            _badgeRepository.CreateNewBadge(13423, doorNamesTwo);
            Assert.AreEqual(expected, _badgeRepository.ViewAllBadges().Count);
        }

        [TestMethod]
        public void AddBadgeDoorsTest()
        {
            int expected = 4;
            _badgeRepository.AddBadgeDoors(12345, "A4");
            int actual = _badge.DoorName.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteBadgeDoorsTest()
        {
            int expected = 2;
            _badgeRepository.DeleteBadgeDoors(12345, "A1");
            int actual = _badge.DoorName.Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
