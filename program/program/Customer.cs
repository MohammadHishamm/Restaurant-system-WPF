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

        private int GenerateOrderId()
        {

            Random rand = new Random();
            return rand.Next(1, 10000);

        }
        public void PlaceOrder(Waiter waiter, List<MenuItem> menuItems)
        {

            int orderId = GenerateOrderId();
            //Order order = new Order(orderId, "Pending");
            foreach (var item in menuItems)
            {
               // order.AddMenuItem(item);
            }
            //waiter.CreateOrder(order);

            Console.WriteLine($"Order placed successfully. Order ID: {orderId}");
        }
        public void Update(Order order)
        {
           
        }

        public void NotifyCustomer(Order order)
        {
           
            Console.WriteLine($"Dear {Name}, your order {order.OrderID} status has been updated to {order.Status}.");
        }

    }
}
