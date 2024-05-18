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
                // Create an instance of the DBconfig class
                DBconfig db = DBconfig.Instance;

                // Open connection
                db.OpenConnection();

                // Insert item into the database
                string insertQuery = $"INSERT INTO Inventory (Name, Quantity) VALUES ('{itemName}', {quantity})";
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
                // Open connection
                db.OpenConnection();

                // Retrieve items from the database
                string query = "SELECT Name, Quantity FROM Inventory";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            int quantity = reader.GetInt32(1);

                            // Add or update inventory item in the dictionary
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
                // Handle exception
                throw new Exception($"Error loading items from database: {ex.Message}");
            }
            finally
            {
                // Close connection
                db.CloseConnection();
            }
        }




    }



       
}
