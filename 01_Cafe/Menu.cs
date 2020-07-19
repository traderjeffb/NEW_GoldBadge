using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class Menu
    {
            
        public int MenuNum { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string Ingredients { get; set; }
        public float Price { get; set; }


        public Menu() { }//empty constructor
        public Menu(int menuNum, string mealName, string mealDescription, string ingredients, float price)
        {
            MenuNum = menuNum;
            MealName = mealName;
            MealDescription = mealDescription;
            Ingredients = ingredients;
            Price = price;
        }
    }
}

