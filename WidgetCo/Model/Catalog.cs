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
    public class Catalog : CatalogBase, ICatalog
    {
        public Catalog()
            : base()
        {
            Read();
        }

        /// <summary>
        /// Create the path to the Catalog input file, then read it in
        /// </summary>
        private void Read()
        {
            String currentPath = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String dataDirectory = "\\..\\..\\Data\\";
            String catalogFile = "Catalog.txt";
            String catalogPath = currentPath + dataDirectory + catalogFile;
            ReadCatalog(catalogPath);
        }

        /// <summary>
        /// Stub function for saving a modified catalog file
        /// </summary>
        private void Save()
        {
            //Stub
        }
        
        /// <summary>
        /// Catalog Format: Version ID, Header, Item information
        /// 
        /// Version	3
        /// ProductID	ProductName	    Category
        /// 1	        Running Shoe	Running
        /// 2	        Dress Shoe	    Dress
        /// 
        /// </summary>
        /// <param name="path">Windows path string</param>
        private void ReadCatalog(String path)
        {
            string line;
            Int32 output;

            // Read the file and display it line by line.
            using (StreamReader file = new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {

                    char[] delimiters = new char[] { '\t' };
                    List<String> parts = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
                    switch (parts[0])
                    {
                        //Check for Version information
                        case "Version":
                            if (parts[1] != "3")
                                throw new NotSupportedException("This catalog does no comply with the current format");
                            break;
                        //Make sure header is correct
                        case "ProductID":
                            if (parts[1] != "ProductName" && parts[2] != "Category")
                                throw new NotSupportedException("This catalog does no comply with the current format");
                            break;
                        default:
                            if (Int32.TryParse(parts[0], out output))
                            {
                                IDTable.Add(parts[0], parts[1]);
                                CategoryTable.Add(parts[0], parts[2]);
                            }
                            else
                                throw new NotSupportedException("This catalog does no comply with the current format");
                            break;
                    }
                }
                file.Close();
            }
        }
    }
}
