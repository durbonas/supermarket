using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        
        static void Main(string[] args)
        {   
            //Create a new Grocery List
            var myGroceryList = new GroceryList();

            //Cycle through shopping list and add items
            foreach (var item in args)
            {   
                //For every shopping item create new GroceryItem Object
                var GroceryPurchase = new GroceryItem(item);

                //Add GroceryItem to my shopping list
                myGroceryList.AddGroceryItem(GroceryPurchase);
            }

            //Print out my shopping list
            foreach (var item in myGroceryList.GroceryItemsList)
            {
                System.Console.WriteLine($"{item.name}...............{item.price}");
            }

        }
    }
}
