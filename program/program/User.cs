using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class User   // Encapsulation 
    {
        private int Id { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        public string Type { get; set; }

        // Constructor
        public User(string email, string password)
        {
            
            Email = email;
            Password = password;
        }

        // Getter for Id
        public int GetId()
        {
            return Id;
        }

        // Setter for Id
        public void SetId(int id)
        {
            Id = id;
        }

        // Getter for Email
        public string GetEmail()
        {
            return Email;
        }

        // Setter for Email
        public void SetEmail(string email)
        {
            Email = email;
        }

        // Getter for Password
        public string GetPassword()
        {
            return Password;
        }
        public string Gettype()
        {
            return Type;
        }
        public void Settype(string type)
        {
            Type= type;
        }

        // Setter for Password
        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
