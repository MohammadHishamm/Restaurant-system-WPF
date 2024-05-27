using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public class ExtraToppingsDecorator : MenuItemDecorator
    {
        private string _topping;
        private decimal _toppingPrice;

        public ExtraToppingsDecorator(MenuItem menuItem, string topping, decimal toppingPrice) : base(menuItem)
        {
            _topping = topping;
            _toppingPrice = toppingPrice;
        }

     

        public override decimal Price
        {
            get { return _menuItem.Price + _toppingPrice; }
        }
    }
}
