using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductAssignment.Importers
{
    public class SoftwareAdviceImporter : ProductImporter
    {
        public SoftwareAdviceImporter(string resourcePath) : base(resourcePath)
        {
        }
        /// <summary>
        /// Deserialize the json format into Product list
        /// </summary>
        /// <returns>List of products</returns>
        public override List<Product> Deserialize()
        {
            try
            {
                string json = File.ReadAllText(ResourcePath);

                JObject jObject = JObject.Parse(json);
                var productsJson = jObject["products"];
                List<Product> products = new List<Product>();
                foreach (var token in productsJson)
                {
                    var title = token["title"]?.Value<string>();
                    var twitter = token["twitter"]?.Value<string>();
                    var categoriesList = token["categories"]?.Select(a => a.Value<string>());
                    string categories = string.Join(", ", categoriesList);

                    Product product = new Product()
                    {
                        Name = title,
                        Twitter = twitter,
                        Categories = categories,
                    };
                    products.Add(product);
                }
                return products;
            }
            catch (Exception ex)
            {
                //Log error to logger
                Console.WriteLine(ex.Message);
                return null;
            }

        }

    }
}
