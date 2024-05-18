    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace program
    {
        public class MenuItem
        {
            public int MenuItemID { get; private set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }


            public MenuItem(int menuItemID, string title, string description, decimal price)
            {
                MenuItemID = menuItemID;
                Title = title;
                Description = description;
                Price = price;
            }
            public void UpdatePrice(decimal newPrice)
            {
                Price = newPrice;
            }
        }
    }
