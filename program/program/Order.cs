using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace program
{
    internal class Order
    {
        public int OrderID { get; private set; }
        public string Status { get; set; }
        public MenuItem MenuItem { get; private set; }
        public int TableID { get; private set; }
        private List<IObserver> observers;
        private readonly DBconfig db;
        
        public Order(int orderID, string status, int tableID)
        {
            db = DBconfig.Instance;
            OrderID = orderID;
            Status = status;
    
            TableID = tableID;
            observers = new List<IObserver>();
        }

        public Order()
        {
            db = DBconfig.Instance;
        }

        public void AddItemToDatabase(int ID, String status, int table)
        {
            try
            {
                // Create an instance of the DBconfig class
               

                // Open connection
                db.OpenConnection();

                // Insert item into the database
                string insertQuery = $"INSERT INTO [Order] (ID, Status, TableID) VALUES ({ID}, '{status}' , {table})";
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







        public List<Order> LoadItemsFromDatabase()
        {
            List<Order> orders = new List<Order>();

            try
            {
                // Open connection
                db.OpenConnection();

                // Retrieve items from the database
                string query = "SELECT ID, Status, TableID FROM [Order]";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string status = reader.GetString(1);
                            int table = reader.GetInt32(2);

                            Order order = new Order(id, status, table);
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error loading items from database: {ex.Message}");
            }
            finally
            {
                // Close connection
                db.CloseConnection();
            }

            return orders;
        }






        //public void RemoveMenuItem(MenuItem menuItem)
        //{
        //    if (MenuItems.Contains(menuItem))
        //    {
        //        MenuItems.Remove(menuItem);
        //        Console.WriteLine($"Removed '{menuItem.Title}' from order {OrderID}.");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Item '{menuItem.Title}' is not in order {OrderID}. Cannot remove.");
        //    }
        //}

        //public void ViewOrderDetails()
        //{
        //    Console.WriteLine($"Order Details for Order {OrderID}:");
        //    foreach (var item in MenuItems)
        //    {
        //        Console.WriteLine($"ID: {item.MenuItemID}, Title: {item.Title}, Description: {item.Description}, Price: {item.Price}");
        //    }
        //}

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


