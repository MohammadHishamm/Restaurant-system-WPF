using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Waiter
    {
        private List<Order> orders;

        public Waiter()
        {
            orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
            Console.WriteLine($"New order created. Order ID: {order.OrderID}");
        }
    }
}
