using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WidgetCo.Model
{
    /// <summary>
    /// ICatalog interface for any catalog object
    /// </summary>
    public interface ICatalog
    {
        Dictionary<String, String> IDTable { get; set; }
        Dictionary<String, String> CategoryTable { get; set; }

        List<String> FetchIDs(String category);
        String FetchCategory(String itemId);
        List<String> FetchRelated(String itemId);
        String[] FetchRandom();
    }
}
