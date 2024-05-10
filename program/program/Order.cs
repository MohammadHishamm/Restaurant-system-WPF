using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Order
    {
        public int OrderID { get; private set; }
        public string Status { get; set; }
        public List<MenuItem> MenuItems { get; private set; }

        public Order(int orderID, string status)
        {
            OrderID = orderID;
            Status = status;
            MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem menuItem)
        {

            MenuItems.Add(menuItem);
            Console.WriteLine($"Added '{menuItem.Title}' to order {OrderID}.");
        }

        public void RemoveMenuItem(MenuItem menuItem)
        {
            if (MenuItems.Contains(menuItem))
            {
                MenuItems.Remove(menuItem);
                Console.WriteLine($"Removed '{menuItem.Title}' from order {OrderID}.");
            }
            else
            {
                Console.WriteLine($"Item '{menuItem.Title}' is not in order {OrderID}. Cannot remove.");
            }
        }

        public void ViewOrderDetails()
        {
            Console.WriteLine($"Order Details for Order {OrderID}:");
            foreach (var item in MenuItems)
            {
                Console.WriteLine($"ID: {item.MenuItemID}, Title: {item.Title}, Description: {item.Description}, Price: {item.Price}");
            }
        }
    }
}
