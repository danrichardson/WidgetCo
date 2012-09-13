using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace WidgetCo.Model
{
    /// <summary>
    /// Implements the ICatalog interface for the sample catalog file
    /// </summary>
    public class CatalogBase : ICatalog
    {
        #region Properties
        static Random rnd = new Random();
        
        private Dictionary<String, String> _idTable;
        public Dictionary<String, String> IDTable 
        { 
            get
            {
                if (_idTable == null)
                    _idTable = new Dictionary<string,string>();
                return _idTable;
            }
            set
            {
                _idTable = value;
            }
        }

        private Dictionary<String, String> _categoryTable;
        public Dictionary<String, String> CategoryTable 
        { 
            get
            {
                if (_categoryTable == null)
                    _categoryTable = new Dictionary<string, string>();
                return _categoryTable;
            }
            set
            {
                _categoryTable = value;
            }
        }
        #endregion Properties

        #region Constructor

        public CatalogBase()
        {
            //Implement in derived class
            //Read();
        }

        #endregion Constructor

        /// <summary>
        /// Fetch the list of Item ID's that correspond to the category desired
        /// </summary>
        /// <param name="category">Category interested in</param>
        /// <returns>List of Item ID's</returns>
        public List<String> FetchIDs(String category)
        {
            return CategoryTable.Where(o => o.Value == category).Select(o => o.Key).ToList();
        }

        /// <summary>
        /// Given an Item ID, return the item's category
        /// </summary>
        /// <param name="itemId">Item ID</param>
        /// <returns>Item's Category</returns>
        public String FetchCategory(String itemId)
        {
            return CategoryTable.Where(o => o.Key == itemId).Select(o => o.Value).Single();
        }
        
        /// <summary>
        /// Given an Item ID, return all the related items that share the same category,
        /// EXCEPT for the item itself.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public List<String> FetchRelated(String itemId)
        {
            String category = FetchCategory(itemId);
            return IDTable.AsQueryable().Where(o => FetchIDs(category).Contains(o.Key) && o.Key != itemId).Select(o => o.Value).ToList();
        }

        /// <summary>
        /// Just for fun, return a random item.  Useful if there aren't any related items to the one selected
        /// </summary>
        /// <returns>Array: [0]: Random Category, [1] Random item from Random Category</returns>
        public String[] FetchRandom()
        {
            int r = rnd.Next(1, IDTable.Count);
            return new String[] { CategoryTable.Where(o => o.Key == r.ToString()).Select(o => o.Value).Single(), IDTable.Where(o => o.Key == r.ToString()).Select(o => o.Value).Single() };
        }
    }
}
