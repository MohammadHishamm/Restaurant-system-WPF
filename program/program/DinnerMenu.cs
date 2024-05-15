using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class DinnerMenu : Menu
    {
        public DinnerMenu(int menuID) : base(menuID) { }

        protected override MenuItem CreateMenuItem(int menuItemID, string title, string description, decimal price)
        {
            return new MenuItem(menuItemID, title, description, price);
        }
    }
}