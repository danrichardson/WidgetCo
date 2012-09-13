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
    public class MockCatalog : CatalogBase, ICatalog
    {
        public MockCatalog()
            : base()
        {
            
        }
    }
}
