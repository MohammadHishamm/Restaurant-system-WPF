using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Inventory
    {
        private readonly DBconfig db;
        public Dictionary<string, int> inventoryItems;

        public Inventory()
        {
            db = DBconfig.Instance;
            inventoryItems = new Dictionary<string, int>();
        }

        public int ItemQuantity(string itemName)
        {
            if (inventoryItems.ContainsKey(itemName))
            {
                return inventoryItems[itemName];
            }
            return 0;
        }

        public bool ItemInStock(string itemName)
        {
            return inventoryItems.ContainsKey(itemName);
        }

        public void AddItemToDatabase(string itemName, int quantity)
        {
            try
            {
             
                DBconfig db = DBconfig.Instance;

            
                db.OpenConnection();

              
                string insertQuery = $"INSERT INTO Inventory (Name, Quantity) VALUES ('{itemName}', {quantity})";
                db.InsertData(insertQuery);

            
                db.CloseConnection();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error adding item to database: {ex.Message}");
            }
        }

        public void RemoveItem(string itemName, int quantity)
        {
            if (inventoryItems.ContainsKey(itemName))
            {
                if (inventoryItems[itemName] >= quantity)
                {
                    inventoryItems[itemName] -= quantity;
                    Console.WriteLine($"{quantity} {itemName}(s) removed from inventory.");
                }
                else
                {
                    Console.WriteLine($"Not enough {itemName} in inventory.");
                }
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
            }
        }

        public void LoadItemsFromDatabase()
        {
            try
            {
              
                db.OpenConnection();

               
                string query = "SELECT Name, Quantity FROM Inventory";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int quantity = reader.GetInt32(1);

                     
                            if (inventoryItems.ContainsKey(name))
                            {
                                inventoryItems[name] = quantity;
                            }
                            else
                            {
                                inventoryItems.Add(name, quantity);
                            }
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
        }
        public void UpdateItemInDatabase(string itemName, int quantity)
        {
            try
            {
                
                db.OpenConnection();

                
                string checkQuery = $"SELECT COUNT(*) FROM Inventory WHERE Name = '{itemName}'";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, db.GetConn()))
                {
                    int itemExists = (int)checkCmd.ExecuteScalar();
                    if (itemExists > 0)
                    {
                      
                        string updateQuery = $"UPDATE Inventory SET Quantity = {quantity} WHERE Name = '{itemName}'";
                        db.InsertData(updateQuery);

                     
                        if (inventoryItems.ContainsKey(itemName))
                        {
                            inventoryItems[itemName] = quantity;
                        }
                        else
                        {
                            inventoryItems.Add(itemName, quantity);
                        }
                    }
                    else
                    {
                        throw new Exception($"Item '{itemName}' does not exist in the inventory.");
                    }
                }
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Error updating item in database: {ex.Message}");
            }
            finally
            {
              
                db.CloseConnection();
            }
        }

        public void DeleteItemFromDatabase(string itemName)
        {
            try
            {
                db.OpenConnection();

           
                string deleteQuery = $"DELETE FROM Inventory WHERE Name = '{itemName}'";

                // Execute the delete query
                db.InsertData(deleteQuery);

              
                if (inventoryItems.ContainsKey(itemName))
                {
                    inventoryItems.Remove(itemName);
                    Console.WriteLine($"{itemName} removed from inventory.");
                }
                else
                {
                    Console.WriteLine($"Item {itemName} not found in inventory.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting item from database: {ex.Message}");
            }
            finally
            {
              
                db.CloseConnection();
            }
        }



    }




}
