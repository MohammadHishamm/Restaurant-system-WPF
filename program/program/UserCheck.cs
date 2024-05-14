using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace program
{
    internal class UserCheck
    {

        public bool SearchUser(User person)
        {
            bool userFound = false;
            DBconfig Db = new DBconfig();
            Db.OpenConnection();
            Encryption aesEncryption = new Encryption();

            string query = "SELECT  id, email, password FROM [user] WHERE email LIKE @SearchTerm AND password LIKE @SearchTerm2";
            SqlCommand command = new SqlCommand(query, Db.GetConn());
            command.Parameters.AddWithValue("@SearchTerm", "%" +person.GetEmail() + "%");
            command.Parameters.AddWithValue("@SearchTerm2", "%" + aesEncryption.Encrypt(person.GetPassword()) + "%");


            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    userFound = true;

                    // Set the values to the user object if needed
                    person.SetId(reader.GetInt32(reader.GetOrdinal("id")));
                    person.SetEmail(reader.GetString(reader.GetOrdinal("email")));
                    person.SetPassword(aesEncryption.Decrypt(reader.GetString(reader.GetOrdinal("password"))));
                   
                    Debug.WriteLine("User found in the database.");
                }
            }

            // Check if user was found
            if (!userFound)
            {
                Debug.WriteLine("User not found in the database.");
            }
            Db.CloseConnection();

            return userFound;
        }
    }
}