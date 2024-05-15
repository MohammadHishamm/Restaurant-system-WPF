using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Waiter: IObserver
    {
        private List<Order> orders;

        public Waiter()
        {
            orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
            order.Attach(this);
            Console.WriteLine($"New order created. Order ID: {order.OrderID}");
        }
        public void Update(Order order)
        {
            Console.WriteLine($"Order {order.OrderID} status changed to {order.Status}");
        }
        public void NotifyCustomer(Order order)
        {
            
            Console.WriteLine($"Order {order.OrderID} status changed to {order.Status}");
        }
    }
}
