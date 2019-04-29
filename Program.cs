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
                //For every shopping list item create new GroceryItem Object
                var GroceryPurchase = new GroceryItem(item);
                Console.WriteLine($"Buying {item}");
                Console.WriteLine("{0},{1}", GroceryPurchase.name, GroceryPurchase.price);
                //Add GroceryItem to my shopping list
                myGroceryList.AddGroceryItem(GroceryPurchase);
                Console.WriteLine("My Grocery List {0}", myGroceryList.GroceryItemsList[0].name);
            }

        }
    }
}
