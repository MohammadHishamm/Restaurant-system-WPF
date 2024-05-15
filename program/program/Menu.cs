using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal abstract class Menu
    {
        public int MenuID { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }

        protected Menu(int menuID)
        {
            MenuID = menuID;
            MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(int menuItemID, string title, string description, decimal price)
        {
            var item = CreateMenuItem(menuItemID, title, description, price);
            MenuItems.Add(item);
        }

        public void RemoveMenuItem(MenuItem item)
        {
            MenuItems.Remove(item);
        }

        public void ViewMenu()
        {
            Console.WriteLine($"Menu ID: {MenuID}");
            Console.WriteLine("Menu Items:");
            foreach (var item in MenuItems)
            {
                Console.WriteLine($"{item.MenuItemID}: {item.Title} - ${item.Price}");
            }
        }

       
        protected abstract MenuItem CreateMenuItem(int menuItemID, string title, string description, decimal price);
    }
}
