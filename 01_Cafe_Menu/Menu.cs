using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class Menu
    {
        public Menu() { }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string IngredientList { get; set; }
        public decimal MealPrice { get; set; }

        public Menu(int mealNumber, string mealName, string mealDescription, string ingredientList, decimal mealPrice)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            IngredientList = ingredientList;
            MealPrice = mealPrice;
        }
    }
}

//The cafe manager at Komodo wants to be able to create a menu item, delete a menu item,
//and list all items on the cafe's menu. She needs a console app. 

//Each of their menu items will contain the following:
//a meal number so employees can say "I'll have the #5", 
//a meal name, 
//a description,
//a list of ingredients in the meal,
//and a price.
