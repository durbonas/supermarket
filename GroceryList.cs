using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket
{
    public class GroceryList
    {
        
        public List<GroceryItem> GroceryCatalogue = new List<GroceryItem>()
        {
            new GroceryItem() {Id ="111", Name="Apple", RegularPrice = 0.49 , DiscountPrice = 0.29, IsPromotional = true, BuyXFreeDeal = 3},
            new GroceryItem() {Id ="222", Name="Orange", RegularPrice = 1.19 , DiscountPrice = .99, IsPromotional = false, BuyXFreeDeal = 2},
            new GroceryItem() {Id ="333", Name="Banana", RegularPrice = .99 , DiscountPrice = .49, IsPromotional = true, BuyXFreeDeal = 0}
        };
        public List<GroceryItem> GroceryReceipt = new List<GroceryItem>();
        public double Total {get;set;}


        public void AddGroceryItem(GroceryItem item) 
        {   
            if(GroceryReceipt.Any(prod => prod.Id == item.Id))
            {   
                var duplicateItem = GroceryReceipt.Single(Item => Item.Id == item.Id);
                duplicateItem.Quantity++;
            }
            else
            {
                GroceryReceipt.Add(item);
                GroceryReceipt.ForEach(Item => Console.WriteLine($"{Item.Id}, {Item.Quantity}, {Item.RegularPrice}, {Item.Price}"));                
            }
        }

        public double TotalGroceryList()
        {
            double totalPrice = 0;
            GroceryReceipt.ForEach(item => totalPrice += item.Quantity * item.Price);
            return totalPrice;
        }

        public int BuyQuantityForOneFree {set;get;}
        public int ItemsCalculatedForFree {set;get;}
      
        public bool BuyXGetYFree(GroceryItem item)
        {
            //Total everything up
            Total = TotalGroceryList();

            BuyQuantityForOneFree = item.BuyXFreeDeal;

            if(BuyQuantityForOneFree == 0) {
                return false;
            }
            else {
                ItemsCalculatedForFree = item.Quantity / BuyQuantityForOneFree;

                if(item.Quantity >= BuyQuantityForOneFree) {
                    Total = (Total - ItemsCalculatedForFree) * item.Price;
                } 

                return true;  
            }
            
        }


        public void PrintReceipt() {

            var PrintOutText = " ";
            
            //Print Header
            PrintOutText += "\n\nBIG DAVE'S PRODUCE STORE\n-------------------------------\n";

            //Print each line item showing promotions
            foreach (var item in GroceryReceipt)
            {   
                //Print out for discout promotion and quantity purchases
                if(item.IsPromotional && BuyXGetYFree(item))
                {
                    PrintOutText += $"{item.Quantity}x {item.Name} \n was ${item.RegularPrice}............NOW ${item.Price} \n Buy {BuyQuantityForOneFree} get 1 FREE! ...{ItemsCalculatedForFree}@ -${item.Price} \n\n";

                    
                } 
                else if(item.IsPromotional)
                {
                    PrintOutText += $"{item.Quantity}x {item.Name} \n was ${item.RegularPrice} NOW ...........${item.Price} \n\n";

                }
                else if(BuyXGetYFree(item))
                {
                    PrintOutText += $"{item.Quantity}x {item.Name} \n Buy {BuyQuantityForOneFree} get 1 FREE! ...{ItemsCalculatedForFree}@ -${item.Price} \n\n";

                }
                else 
                {
                      PrintOutText += $"{item.Quantity}x {item.Name}................${item.Price} \n\n";

                }
            }

            //Print Total and Footer 
            PrintOutText += $"TOTAL....................${Total}\n-------------------------------\nThank you for shopping with us!\n\n";
            Console.WriteLine(PrintOutText);
            Console.WriteLine("Do you want to print this receipt? 'y' = Yes, or any other key to exit");
            var Print = Console.ReadLine();
            if(Print == "y") {
                File.WriteAllText(@"C:\Users\durbonas\source\repos\supermarket\src\Supermarket\ReceiptText.txt", PrintOutText);
                Console.WriteLine("Your Receipt has been printed");
            } else {
                Console.WriteLine("Exiting App");
            } 

        }
    }
}
