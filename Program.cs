using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class Program
    {
        
        static void Main(string[] Barcodes)
        {   
            //Build store list
            var GroceryCatalogue = new GroceryList().BuildGroceryCatalogue();

            //Start Receipt
            var CustomerReceipt = new GroceryList();

            //Cycle through barcodes and add items
            foreach (var barcode in Barcodes)
            {   
                //If barcode matches return item
                var GroceryItem = GroceryCatalogue.SingleOrDefault(prod => prod.Id == barcode);

                //make sure returned item does exist !null
                if(GroceryItem != null)
                {
                   //Add to customer's receipt
                    CustomerReceipt.AddGroceryItem(GroceryItem);
                }
            }

            //Print out my shopping list
            CustomerReceipt.PrintReceipt();

        }
    }
}
