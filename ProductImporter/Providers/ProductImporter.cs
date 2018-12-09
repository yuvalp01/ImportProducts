using System;
using System.Collections.Generic;

namespace ProductAssignment.Importers
{
    public abstract class ProductImporter
    {
        public string ResourcePath { get; }
        public ProductImporter(string resourcePath)
        {
            ResourcePath = resourcePath;
        }

        public abstract List<Product> Deserialize();

        public bool PersistData(List<Product> products)
        {

            try
            {
                //Save data to db, return true if succeed
                foreach (var product in products)
                {
                    Console.WriteLine($"Importing Name: \"{product.Name}\"; Categories: {product.Categories}; Twitter: {product.Twitter} ");
                }
                
            }
            catch (Exception ex)
            {
                //Log error to logger
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;

        }
    }
}
