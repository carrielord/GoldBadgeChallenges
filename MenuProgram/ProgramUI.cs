using _01_Cafe_Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuProgram
{
    class ProgramUI
    {
        private MenuRepository _menuRepository = new MenuRepository();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number for the action you'd like to perform.\n" +
                    "1. Create Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. View All Menu Items\n" +
                    "4. Exit");
                string actionSelection = Console.ReadLine();
                int selectionInt;
                bool success = Int32.TryParse(actionSelection, out selectionInt);
                if (success)
                {
                    switch (selectionInt)
                    {
                        case 1:
                            CreateMenuItem();
                            break;
                        case 2:
                            DeleteMenuItem();
                            break;
                        case 3:
                            ViewMenuItems();
                            break;
                        case 4:
                            continueToRunMenu = false;
                            break;
                        default:
                            Console.WriteLine("Please select valid number 1 through 4.\n" +
                                "Press any key to continue");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter number only.\n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
        private void CreateMenuItem()
        {
            Menu newItem = new Menu();
            Console.WriteLine("Please enter meal name:");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Please enter meal number:");
            string mealNum = Console.ReadLine();
            int mealNumInt;
            bool mealNumberParse = false;
            while (!mealNumberParse)
            {
                mealNumberParse = int.TryParse(mealNum, out mealNumInt);
                if (mealNumberParse)
                {
                    newItem.MealNumber = mealNumInt;
                }
                else
                {
                    Console.WriteLine("Please enter a number only.");
                    mealNum = Console.ReadLine();
                }
            }
            Console.WriteLine("Please enter meal description:");
            newItem.MealDescription = Console.ReadLine();
            Console.WriteLine("Please enter ingredient list:");
            newItem.IngredientList = Console.ReadLine();
            Console.WriteLine("Please enter meal price:");
            string mealPrice = Console.ReadLine();
            decimal mealPriceDec;
            bool mealPriceParse = false;
            while (!mealPriceParse)
            {
                mealPriceParse = decimal.TryParse(mealPrice, out mealPriceDec);
                if (mealPriceParse)
                {
                    newItem.MealPrice = mealPriceDec;
                }
                else
                {
                    Console.WriteLine("Please enter a number only.");
                    mealPrice = Console.ReadLine();
                }
            }
            _menuRepository.CreateMenuItem(newItem);
            Console.WriteLine("Item has been added successfully.\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }
        private void DeleteMenuItem()
        {
            Console.WriteLine("Please enter name of menu item to be deleted.");
            string name = Console.ReadLine();
            Menu deleteItem = _menuRepository.FindMenuItemByName(name);
            _menuRepository.DeleteMenuItem(deleteItem);
            Console.WriteLine("Item has been deleted successfully.\n" +
            "Press any key to continue...");
            Console.ReadKey();
        }
        private void ViewMenuItems()
        {
           List<Menu> menuItemList= _menuRepository.ListAllMenuItems();
            foreach(Menu item in menuItemList)
            {
                Console.WriteLine($"#{item.MealNumber} {item.MealName}:   Description: {item.MealDescription}; Ingredients: {item.IngredientList}; Cost: ${item.MealPrice}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedMenu()
        {
            Menu newItemOne = new Menu(1, "Burger", "Good ol' American burger", "bun, patty, ketchup", 2.50m);
            Menu newItemTwo = new Menu(2, "Fries", "Good ol' French Fries", "potatoes, oil, salt", 1.50m);

            _menuRepository.CreateMenuItem(newItemOne);
            _menuRepository.CreateMenuItem(newItemTwo);
        }
    }
}


