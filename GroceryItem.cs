using System;
using System.Collections.Generic;

namespace Supermarket
{
    public class GroceryItem
    {   
        public string Id {get;set;}
        public string Name {get; set;}
        public bool IsPromotional {get; set;}
        public double RegularPrice {get; set;}
        public double DiscountPrice {get; set;}
        public double Price 
        {
            get {
                return IsPromotionalCheck();
            }
            set {
                Price = value;
            }
        }
        public int Quantity = 1;
        public int BuyXFreeDeal {set;get;}
        
        public double IsPromotionalCheck () {
            if(IsPromotional)
            {
                return DiscountPrice;
            }
            return RegularPrice;
        }

    }

}
