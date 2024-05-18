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
        private List<IObserver> observers;

        public Order(int orderID, string status)
        {
            OrderID = orderID;
            Status = status;
            MenuItems = new List<MenuItem>();
            observers = new List<IObserver>(); ;
        }

        public void AddItemToDatabase(string itemName, int quantity)
        {
            try
            {
                // Create an instance of the DBconfig class
                DBconfig db = DBconfig.Instance;

                // Open connection
                db.OpenConnection();

                // Insert item into the database
                string insertQuery = $"INSERT INTO Order (Name, Quantity) VALUES ('{itemName}', {quantity})";
                db.InsertData(insertQuery);

                // Close connection
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                throw new Exception($"Error adding item to database: {ex.Message}");
            }
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

        public void Attach(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
                observer.NotifyCustomer(this);
            }
        }


        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
            Notify();

        }










    }
}
