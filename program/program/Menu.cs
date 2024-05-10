using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Menu
    {
        public int MenuID { get; private set; }
        public List<MenuItem> MenuItems { get; private set; }

        public Menu(int menuID)
        {
            MenuID = menuID;
            MenuItems = new List<MenuItem>();
        }
        public void AddMenuItem(MenuItem item)
        {
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
                Console.WriteLine($"{item.Title} - ${item.Price}");
            }
        }
    }
}
