using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {

        protected readonly List<Menu> _menu = new List<Menu>();

        //CRUD

        //CREATE
        public bool AddToMenu(Menu content)
        {
            int startingCount = _menu.Count;
            _menu.Add(content);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //READ
        public Menu GetMenuItemByMenuName(string mealName)
        {
            foreach (Menu content in _menu)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }


        //SHOW ALL MENU ITEMS
        //GetMenuItemsAll(int mealNumber, string mealName, string mealDescription, string ingredients, float price )
        public List<Menu> GetContents()
        {
            return _menu;
        }

        public List<Menu> ShowAllMenuItems()
        {
            List<Menu> allMenuItems = new List<Menu>();
            foreach (Menu content in _menu)
            {
                if (content is Menu)
                {
                    allMenuItems.Add((Menu)content);
                }
            }
            return allMenuItems;
        }

        //DELETE
        public bool DeleteExistingMenuItem(Menu existingContent)
        {
            bool deleteResult = _menu.Remove(existingContent);
            return deleteResult;
        }


    }
}

