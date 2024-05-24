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
        public class MenuItem
        {
            public int MenuItemID { get; private set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
         private readonly DBconfig db;


        public MenuItem(int menuItemID, string title, string description, decimal price)
            {
                MenuItemID = menuItemID;
                Title = title;
                Description = description;
                Price = price;
            db = DBconfig.Instance;

        }

           public MenuItem() {
            db = DBconfig.Instance;
                 }

        public void AddItemToDatabase(int menuid,string itemName, string description, decimal price)
        {
            try
            {

                DBconfig db = DBconfig.Instance;


                db.OpenConnection();
            


                string insertQuery = $"INSERT INTO [Menuitem] (MenuID, Title, Description, Price) VALUES ({menuid}, '{itemName}', '{description}', {price})";
                db.InsertData(insertQuery);


                db.CloseConnection();
            }
            catch (Exception ex)
            {

                throw new Exception($"Error adding item to database: {ex.Message}");
            }
         }
        public List<MenuItem> LoadItemsFromDatabase()
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            try
            {

                db.OpenConnection();

                string query = "SELECT MenuID, Title, Description, Price FROM [Menuitem]";
                using (SqlCommand cmd = new SqlCommand(query, db.GetConn()))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string title = reader.GetString(1);
                            string description = reader.GetString(2);
                            decimal price = reader.GetDecimal(3);

                            MenuItem menuitem = new MenuItem(id,title, description, price);
                            menuItems.Add(menuitem);
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

            return menuItems;
        }














    }


    }
