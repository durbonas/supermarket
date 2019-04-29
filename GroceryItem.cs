using System;
using System.Collections.Generic;

namespace Supermarket
{
    class GroceryItem
    {
        public GroceryItem(string Name) {
            _name = Name;
            _price = getPrice(_name);
        }


        private string _name;
        public string name 
        {
            get 
            {
                return _name;
            } 
            set 
            {
                name = value;
            }
        }

        private double _price {get; set;}
        public double price 
        {
            get 
            {
                return _price;
            } 
            set 
            {
                price = value;
            }
        }

        public double getPrice(string itemName) 
        {
            switch (itemName)
            {
                case "Apples":
                    return _price = 3.99;

                case "Oranges":
                    return _price = 1.99;

                case "Bananas":
                    return _price = 2.49;

                default:
                    return _price = 0.00;
            }
        }

    }

}
