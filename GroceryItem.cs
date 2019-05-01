using System;
using System.Collections.Generic;

namespace Supermarket
{
    class GroceryItem
    {
        public GroceryItem(string Name) {
            _name = Name;
            _regularPrice = 0.00;
            _discountPrice = 0.00;
            _price = getPrice(_name);
            quantity = 1;
            // _isPromotional = false;
            // BuyXFreeDeal = 0;
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
        
        private bool _isPromotional {get; set;}
        public bool isPromotional
        {
            get 
            {
                return _isPromotional;
            } 
            set 
            {
                isPromotional = value;
            }
        }


        private double _regularPrice {get; set;}
        public double regularPrice 
        {
            get 
            {
                return _regularPrice;
            } 
            set 
            {
                regularPrice = value;
            }
        }
        private double _discountPrice {get; set;}
        public double discountPrice 
        {
            get 
            {
                return _discountPrice;
            } 
            set 
            {
                _discountPrice = value;
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

        public int quantity {get; set;}

        public int BuyXFreeDeal {set;get;}
        



        public double getPrice(string itemName) 
        {   
            switch (itemName)
            {
                case "Apples":
                    _isPromotional = true;
                    _regularPrice = 3.99;
                    _discountPrice = 2.99;
                    BuyXFreeDeal = 3;
                    
                    if(isPromotional)
                    {
                        return discountPrice;
                    }
                    return regularPrice;

                case "Oranges":
                    _isPromotional = true;
                    _regularPrice = 2.99;
                    _discountPrice = 1.99;
                    BuyXFreeDeal = 2;
                    
                    if(isPromotional)
                    {
                        return discountPrice;
                    }
                    return regularPrice;

                case "Bananas":
                    _isPromotional = false;
                    _regularPrice = 1.99;
                    _discountPrice = .99;
                    BuyXFreeDeal = 3;
                    
                    if(isPromotional)
                    {
                        return discountPrice;
                    }
                    return regularPrice;

                default:
                    return 0.00;
            }
        }

    }

}
