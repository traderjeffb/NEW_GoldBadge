using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Console
{
    public class ProgramUI
    {
            
        Menu _menuRepo = new Menu();
        MenuRepository _repo = new MenuRepository();
        public void Run()
        {
            SeedMenuItemsList();
            RunMenu();
        }

        private void RunMenu()
        {
            //   string input = "";
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Please select a number from below: \n" +
                    "1. Show all menu items \n" +
                    "2. Find menu items by menu name \n" +
                    "3. Add new menu items \n" +
                    "4. remove menu items \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //show all
                        ShowAllMenuItems();
                        break;
                    case "2"://-------------------------------------------****
                        //find by title
                        GetMenuItemByMenuName();
                        break;//----------------------------------------------***
                    case "3":
                        //Add new 
                        AddToMenu();
                        //add all properties of Menu type here?
                        break;
                    case "4":
                        //remove
                        DeleteExistingMenuItem();
                        break;
                    case "5":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5. \n" +
                            "Press any key to continue....");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddToMenu()
        {
            Console.Clear();
            Menu _menu = new Menu();//-------new instance of Menu = _menu

            // meal number
            Console.WriteLine("Please enter the Menu Number: ");
            _menu.MenuNum = int.Parse(Console.ReadLine());

            //meal name
            Console.WriteLine("Please enter the Name of the Menu Name: ");
            _menu.MealName = Console.ReadLine();

            //description
            Console.WriteLine("Please enter the meal description: ");
            _menu.MealDescription = Console.ReadLine();

            Console.WriteLine("Please enter the meal ingredients: ");
            _menu.Ingredients = Console.ReadLine();

            Console.WriteLine("Please enter the Price of the meal: ");
            _menu.Price = float.Parse(Console.ReadLine());

            _repo.AddToMenu(_menu);
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfMenuItems = _repo.ShowAllMenuItems();

            foreach (Menu contentItem in listOfMenuItems)
            {
                DisplayContent(contentItem);
                Console.WriteLine("---------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void GetMenuItemByMenuName()
        {
            Console.Clear();
            Console.WriteLine("Enter a Menu Name");
            string MealName = Console.ReadLine();
            Menu foundMenuName = _repo.GetMenuItemByMenuName(MealName);
            if (foundMenuName != null)
            {
                DisplayContent(foundMenuName);
            }
            else
            {
                Console.WriteLine("Invalid title. Cound not find any results.");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void DeleteExistingMenuItem()
        {
            Console.WriteLine("Which item would you like to remove?");
            List<Menu> listOfMenuItems = _repo.GetContents();
            int count = 0;
            foreach (Menu content in listOfMenuItems)
            {
                count++;
                Console.WriteLine($"{count}. {content.MealName}");
            }

            int targetContentId = int.Parse(Console.ReadLine());
            int targetIndex = targetContentId - 1;
            if (targetIndex >= 0 && targetIndex < listOfMenuItems.Count)
            {
                Menu desiredContent = listOfMenuItems[targetIndex];
                if (_repo.DeleteExistingMenuItem(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.MealName} successfully removed.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, Dave. I'm afraid I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No content has that ID");
            }
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private void DisplayContent(Menu content)
        {
            Console.WriteLine($"MenuNum: {content.MenuNum} \n" +
                $"MealName: {content.MealName} \n" +
                $"Meal Description: {content.MealDescription} \n" +
                $"Ingredients: {content.Ingredients} \n" +
                $"Price: {content.Price}");
        }


        public void SeedMenuItemsList()
        {
            Menu menuItem1 = new Menu(int.Parse("1"), "Chicken", "Chicken with garlic sauce", "Chicken,peas,rice, sauce", float.Parse("12.50"));
            Menu menuItem2 = new Menu(int.Parse("2"), "Beef", "Beef with garlic sauce", "Beef,peas,rice, sauce", float.Parse("13.50"));
            Menu menuItem3 = new Menu(int.Parse("1"), "Pork", "Pork with garlic sauce", "Pork,peas,rice, sauce", float.Parse("10.50"));

            _repo.AddToMenu(menuItem1);
            _repo.AddToMenu(menuItem2);
            _repo.AddToMenu(menuItem3);
        }
    }
}

