using System;
using _01_Cafe_Menu;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Menu_Repository_Tests
{
    [TestClass]
    public class MenuRepositoryTest
    {
        private MenuRepository _menuRepository;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepository = new MenuRepository();
            _menu = new Menu(6, "French Fries", "Just your basic french fries.", "potatoes, oil, salt", 2.09m);
        }

        [TestMethod]
        public void AddMenuItemTest()
        {
            _menuRepository.CreateMenuItem(_menu);
            int expected = 1;
            int actual= _menuRepository.ListAllMenuItems().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveMenuItemTest()
        {
            _menuRepository.CreateMenuItem(_menu);
            bool wasRemoved = _menuRepository.DeleteMenuItem(_menu);
            Assert.IsTrue(wasRemoved);
        }
    }
}
