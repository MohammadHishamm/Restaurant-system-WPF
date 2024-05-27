using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Customer : IObserver
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public int CustomerID { get; private set; }
       


        public Customer(string name, string contactNumber, int customerID)
        {
            Name = name;
            ContactNumber = contactNumber;
            CustomerID = customerID;
        }

    
     
        public void Update(Order order)
        {
            Console.WriteLine($"Customer {Name}: Your order {order.OrderID} status is now {order.Status}");

        }

    

    }
}
