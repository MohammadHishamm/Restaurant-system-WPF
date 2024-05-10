using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Inventory
    {
        private Dictionary<string, int> inventoryItems;

        public Inventory()
        {
            inventoryItems = new Dictionary<string, int>();
        }

        public int ItemQuantity(string itemName)
        {
            if (inventoryItems.ContainsKey(itemName))
            {
                return inventoryItems[itemName];
            }
            return 0;
        }

        public bool ItemInStock(string itemName)
        {
            return inventoryItems.ContainsKey(itemName);
        }

        public void AddItem(string itemName, int quantity)
        {
            if (inventoryItems.ContainsKey(itemName))
            {
                inventoryItems[itemName] += quantity;
            }
            else
            {
                inventoryItems[itemName] = quantity;
            }
        }

        public void RemoveItem(string itemName, int quantity)
        {
            if (inventoryItems.ContainsKey(itemName))
            {
                if (inventoryItems[itemName] >= quantity)
                {
                    inventoryItems[itemName] -= quantity;
                    Console.WriteLine($"{quantity} {itemName}(s) removed from inventory.");
                }
                else
                {
                    Console.WriteLine($"Not enough {itemName} in inventory.");
                }
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
            }
        }

        public Dictionary<string, int> GetInventoryItems()
        {
            return inventoryItems;
        }

        public void ViewInventoryItems()
        {
            Console.WriteLine("Inventory Items:");
            foreach (var item in GetInventoryItems())
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
