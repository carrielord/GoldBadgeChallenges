using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Menu
{
    public class MenuRepository
    {
        private List<Menu> _menuItemList = new List<Menu>();

        public void CreateMenuItem(Menu newItem)
        {
            _menuItemList.Add(newItem);
        }

        public bool DeleteMenuItem(Menu removeItem)
        {
            int initialCount = _menuItemList.Count;
            _menuItemList.Remove(removeItem);
            if (_menuItemList.Count < initialCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Menu> ListAllMenuItems()
        {
            return _menuItemList;
        }
        public Menu FindMenuItemByName(string name)
        {
            foreach (Menu item in _menuItemList)
            {
                if(item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}

//The cafe manager at Komodo wants to be able to create a menu item, delete a menu item,
//and list all items on the cafe's menu. She needs a console app. 