using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    public abstract class MenuItemDecorator : MenuItem
    {
        protected MenuItem _menuItem;

        public MenuItemDecorator(MenuItem menuItem) : base(menuItem.MenuItemID, menuItem.Title, menuItem.Description, menuItem.Price)
        {
            _menuItem = menuItem;
        }

      
    }
}
