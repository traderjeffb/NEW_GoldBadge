using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_MenuRepository_Unit_Tests
{
    [TestClass]
    public class Cafe_Tests
    {

        public class MenuRepositorys
        {


            public readonly List<Menu> _menu = new List<Menu>();

            public void SeedMenuItemsList()
            {
                Menu menuItem1 = new Menu(int.Parse("1"), "Chicken", "Chicken with garlic sauce", "Chicken,peas,rice, sauce", float.Parse("12.50"));
                Menu menuItem2 = new Menu(int.Parse("2"), "Beef", "Beef with garlic sauce", "Beef,peas,rice, sauce", float.Parse("13.50"));
                Menu menuItem3 = new Menu(int.Parse("1"), "Pork", "Pork with garlic sauce", "Pork,peas,rice, sauce", float.Parse("10.50"));

                _menu.Add(menuItem1);
                _menu.Add(menuItem2);
                _menu.Add(menuItem3);
            }

            [TestMethod]
            public void AddToMenu()
            {
                //arragnge
                int startingCount = _menu.Count;
                //act

                Menu menuItem8 = new Menu(int.Parse("8"), "BBQ", "BBQ sauce", "BBQ  sauce", float.Parse("1.50"));
                _menu.Add(menuItem8);
                int afterAddingCount = _menu.Count;
                //assert
                Assert.AreNotEqual(startingCount, afterAddingCount);

            }

            [TestMethod]

            public void GetMenuItemByMenuName_ShouldGetMenuItemByName()
            {
                //arrange
                MenuRepository _repo = new MenuRepository();

                Menu menuItem8 = new Menu(int.Parse("8"), "BBQ", "BBQ", "BBQ", float.Parse("7.50"));
                _repo.AddToMenu(menuItem8);

                // Act
                Menu testMenuName = _repo.GetMenuItemByMenuName("BBQ");

                //Assert
                Assert.AreEqual(testMenuName, menuItem8);
            }


            [TestMethod]
            public void GetContentsShouldShowAll()
            {
                //Arrange
                MenuRepository _repo = new MenuRepository();
                Menu menuItem8 = new Menu(int.Parse("8"), "BBQ", "BBQ", "BBQ", float.Parse("7.50"));

                //Act
                _repo.AddToMenu(menuItem8);
                //Assert
                 
                Assert.IsTrue(_repo.GetContents().Contains(menuItem8));

            }
            //Delete test
            [TestMethod]
            public void Delete_ShouldRemoveMenuItem()
            {
                MenuRepository _repo = new MenuRepository();
                //arrange
                Menu menuItem1 = new Menu(int.Parse("1"), "Chicken", "Chicken with garlic sauce", "Chicken,peas,rice, sauce", float.Parse("12.50"));
                Menu menuItem2 = new Menu(int.Parse("2"), "Beef", "Beef with garlic sauce", "Beef,peas,rice, sauce", float.Parse("13.50"));
                Menu menuItem3 = new Menu(int.Parse("1"), "Pork", "Pork with garlic sauce", "Pork,peas,rice, sauce", float.Parse("10.50"));

                _menu.Add(menuItem1);
                _menu.Add(menuItem2);
                _menu.Add(menuItem3);
                //act
                _repo.DeleteExistingMenuItem(menuItem1);

                //assert
                Assert.IsFalse(_repo.GetContents().Contains(menuItem1));
            }


        }
    }
}

