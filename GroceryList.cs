using System;
using System.Collections.Generic;

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
        public void AddGroceryItem(GroceryItem Item) 
        {
            _GroceryItemsList.Add(Item);
        }

    }

}
