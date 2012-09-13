using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WidgetCo.Model;
using System.Collections.ObjectModel;

namespace WidgetCo.ViewModels
{
    public class ChooseWidgetsViewModel
    {
        public ICatalog catalog;

        /// <summary>
        /// Catalog of items that the user can select from.  I used a dictionary instead of a List
        /// to avoid having a second lookup in the code (ItemName -> ItemID), and also to avoid the
        /// lookup altogether since there could be a case where ID's clash and a lookup would return
        /// multiple ID's.  Since we read the catalog in once and map the line ID string to the ItemName string
        /// it doesn't matter if there is a clash of ID values
        /// 
        /// A dictionary isn't observable, so the WPF won't respond appropriately if items are modified,
        /// but since this is only getting instantiated during contruction of the VM, it's OK to use
        /// </summary>
        private Dictionary<String, String> _itemList = new Dictionary<String, String>();
        public Dictionary<String, String> ItemList
        {
            get { return _itemList; }
            set { _itemList = value; }
        }
        /// <summary>
        /// Collection of items that are related by category to the selected item in the ItemList
        /// Since it's a UI bound object that is dynamically changing, it has to be an observable collection
        /// vs an array or List
        /// </summary>
        private ObservableCollection<String> _relatedItems = new ObservableCollection<string>();
        public ObservableCollection<String> RelatedItems 
        {
            get { return _relatedItems; }
            set { _relatedItems = value; }
        }
        
        /// <summary>
        /// Selected item bound to the UI.  On changed, the Related Items collection is
        /// updated to reflect the new selected item
        /// </summary>
        private KeyValuePair<String, String> _mySelectedItem;
        public KeyValuePair<String, String> MySelectedItem
        {
            get 
            { 
                return _mySelectedItem;
            }
            set
            {
                _mySelectedItem = value;
                List<String> relatedItems = catalog.FetchRelated(_mySelectedItem.Key);
                RelatedItems.Clear();
                if (relatedItems.Count() == 0)
                {
                    string[] randomItem = catalog.FetchRandom();
                    RelatedItems.Add("Have you ever thought about " + randomItem[0] + "?  Try these " + randomItem[1]);
                }
                else
                    foreach (String relatedItem in relatedItems)
                        RelatedItems.Add(relatedItem);
            }
        }

        public ChooseWidgetsViewModel()
        {
            catalog = new Catalog();
            foreach (KeyValuePair<String, String> catalogItem in catalog.IDTable)
                ItemList.Add(catalogItem.Key, catalogItem.Value);
        }
    }
}
