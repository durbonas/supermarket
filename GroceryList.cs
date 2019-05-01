using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    class GroceryList
    {
        private List<GroceryItem> _GroceryItemsList = new List<GroceryItem>();
        public List<GroceryItem> GroceryItemsList
        {
            get {
                return _GroceryItemsList;
            }
            set {
                GroceryItemsList = value;
            }
        }

        private double _Total {get;set;}
        public double Total
        {
            get 
            {
                return _Total;
            } 
            set 
            {
                Total = value;
            }
        }

        public void AddGroceryItem(GroceryItem Item) 
        {   
            
            if(_GroceryItemsList.Any(prod => prod.name == Item.name))
            {   
                var duplicateItem = _GroceryItemsList.FindLast(prod => prod.name == Item.name);
                duplicateItem.quantity++;
            }
            else
            {
                _GroceryItemsList.Add(Item);
            }
        }

        public void BuyThreeGetOneFree(GroceryItem Item)
        {   
            for (int i = 0; i < _GroceryItemsList.Count; i++)
            {
                var count = i;
                
                if(count == 2)
            {   
                Item.price = 0.00;
                Console.WriteLine("Buy 2 get 1 Free");
            } 
            else 
            {
                Item.price = Item.regularPrice;
            }

            }
            
        }

        public double TotalGroceryList()
        {
            double totalPrice = 0;

            foreach (var item in _GroceryItemsList)
            {   
                totalPrice += item.quantity * item.price;
            }

            return totalPrice;
        }

        public int BuyQuantityForOneFree {set;get;}
        public int ItemsCalculatedForFree {set;get;}
        public bool BuyXGetYFree(GroceryItem item)
        {
            //Total everything up
            _Total = TotalGroceryList();

            BuyQuantityForOneFree = item.BuyXFreeDeal;
            ItemsCalculatedForFree = item.quantity / BuyQuantityForOneFree;

            if(item.quantity >= BuyQuantityForOneFree) {
                _Total = (_Total - ItemsCalculatedForFree) * item.price;
                return true;
            } return false;
        }


        public void PrintReceipt() {
            //Print Header
            System.Console.WriteLine("\n\nBIG DAVE'S PRODUCE STORE\n-------------------------------");

            //Print each line item showing promotions
            foreach (var item in GroceryItemsList)
            {   
                //Print out for discout promotion and quantity purchases
                if(item.isPromotional && BuyXGetYFree(item))
                {
                    Console.WriteLine($"{item.quantity}x {item.name} \n was ${item.regularPrice}............NOW ${item.price} \n Buy {BuyQuantityForOneFree} get 1 FREE! ...{ItemsCalculatedForFree}@ -${item.price} \n");
                } 
                else if(item.isPromotional)
                {
                    Console.WriteLine($"{item.quantity}x {item.name} \n was ${item.regularPrice} NOW ...........${item.price} \n");
                }
                else if(BuyXGetYFree(item))
                {
                    Console.WriteLine($"{item.quantity}x {item.name} \n Buy {BuyQuantityForOneFree} get 1 FREE! ...{ItemsCalculatedForFree}@ -${item.price} \n");
                }
                else 
                {
                      Console.WriteLine($"{item.quantity}x {item.name}................${item.price} \n");
                }
            }

            //Print Total and Footer 
                Console.WriteLine($"TOTAL....................${Total}\n-------------------------------\nThank you for shopping with us!\n\n");
        }
    }

}
