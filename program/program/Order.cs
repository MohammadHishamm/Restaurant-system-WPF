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

        public void AddItemToDatabase(int ID, String status, int tableid,int userid)
        {
            try
            {
          
                db.OpenConnection();

          
                string insertQuery = $"INSERT INTO [Order] (ID, Status, TableID, UserID) VALUES ({ID}, '{status}' , {tableid}, {userid})";
                db.InsertData(insertQuery);

                db.CloseConnection();
            }
            catch (Exception ex)
            {
             
                throw new Exception($"Error adding item to database: {ex.Message}");
            }
        }







        public List<Order> LoadItemsFromDatabase()
        {
            List<Order> orders = new List<Order>();

            try
            {
                
                db.OpenConnection();

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

             
                string query = "SELECT ID, Status, TableID FROM [Order] WHERE UserID = @UserID";
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

                            Order order = new Order(id, status, table);
                            orders.Add(order);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
              
                Console.WriteLine("An error occurred: " + ex.Message);
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
                using (var command = new SqlCommand(deleteQuery, db.GetConn()))
                {
                    command.Parameters.AddWithValue("@ID", ID);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Order with ID {ID} removed from the database.");
                    }
                    else
                    {
                        Console.WriteLine($"Order with ID {ID} not found in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting item from the database: {ex.Message}");
            }
            finally
            {
                // Close the database connection
                db.CloseConnection();
            }
        }



        public void UpdateOrderInDatabase(int orderID, string newStatus, int newTableID)
        {
            try
            {
                db.OpenConnection();

                // Check if the order exists
                string checkQuery = $"SELECT COUNT(*) FROM [Order] WHERE ID = {orderID}";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, db.GetConn()))
                {
                    int orderExists = (int)checkCmd.ExecuteScalar();
                    if (orderExists > 0)
                    {
                        // Update the order details
                        string updateQuery = $"UPDATE [Order] SET Status = '{newStatus}', TableID = {newTableID} WHERE ID = {orderID}";
                        db.InsertData(updateQuery);
                    }
                    else
                    {
                        throw new Exception($"Order with ID {orderID} does not exist.");
                    }
                }
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


