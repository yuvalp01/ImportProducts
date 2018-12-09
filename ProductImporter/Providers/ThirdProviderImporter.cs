using System;
using System.Collections.Generic;


namespace ProductAssignment.Importers
{
    public class ThirdProviderImporter : ProductImporter
    {

        public ThirdProviderImporter(string resourcePath) : base(resourcePath)
        {
        }
        //In the future, for the new provider we will implement here his csv online file.
        /// <summary>
        /// Deserialize the csv format into Product list
        /// </summary>
        /// <returns>List of products</returns>
        public override List<Product> Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
