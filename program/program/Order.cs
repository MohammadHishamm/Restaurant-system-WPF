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
        public String MenuItem { get; private set; }
        public int TableID { get; private set; }
        private readonly List<IObserver> observers;
        private readonly DBconfig db;

        public Order(int orderID, string status, int tableID, String menuItem)
        {
            db = DBconfig.Instance;
            OrderID = orderID;
            Status = status;
            MenuItem = menuItem;
            TableID = tableID;
            observers = new List<IObserver>();
        }

        public Order()
        {
            db = DBconfig.Instance;
            observers = new List<IObserver>();
        }

        public void AddItemToDatabase(int ID, string status, int tableid, int userid, String menuItem)
        {
            try
            {
                db.OpenConnection();
                string insertQuery = $"INSERT INTO [Order] (ID, Status, TableID, UserID, MenuItem) VALUES ({ID}, '{status}', {tableid}, {userid}, '{menuItem}')";
                db.InsertData(insertQuery);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding item to database: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public List<Order> LoadItemsFromDatabase()
        {
            List<Order> orders = new List<Order>();

            try
            {
                db.OpenConnection();
                string query = "SELECT ID, Status, TableID, MenuItem FROM [Order]";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string status = reader.GetString(1);
                            int table = reader.GetInt32(2);
                            string menuItemTitle = reader.GetString(3);


                    

                            Order order = new Order(id, status, table, menuItemTitle);
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading items from database: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            return orders;
        }

      

        public List<Order> LoadItemsFromDatabaseByUserId(int userId)
        {
            List<Order> orders = new List<Order>();

            try
            {
                db.OpenConnection();
                string query = "SELECT ID, Status, TableID, MenuItem FROM [Order] WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string status = reader.GetString(1);
                            int table = reader.GetInt32(2);
                            string menuItemTitle = reader.GetString(3);


                            

                            Order order = new Order(id, status, table, menuItemTitle);
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading items from database: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }

            return orders;
        }

        public void DeleteItemFromDatabase(int ID)
        {
            try
            {
                db.OpenConnection();
                string deleteQuery = $"DELETE FROM [Order] WHERE ID = {ID}";
                db.InsertData(deleteQuery);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting item from the database: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
            }
        }

        public void UpdateOrderInDatabase(int orderID, string newStatus, int newTableID)
        {
            try
            {
                db.OpenConnection();
                string updateQuery = $"UPDATE [Order] SET Status = '{newStatus}', TableID = {newTableID} WHERE ID = {orderID}";
                db.InsertData(updateQuery);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order in database: {ex.Message}");
            }
            finally
            {
                db.CloseConnection();
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
            }
        }

        public void ChangeStatus(string newStatus)
        {
            Status = newStatus;
            Notify();
        }


    }
}


