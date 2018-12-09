using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.RepresentationModel;

namespace ProductAssignment.Importers
{
    public class CapterraImporter : ProductImporter
    {
        public CapterraImporter(string resourcePath) : base(resourcePath)
        {
        }
        /// <summary>
        /// Deserialize the yaml format into Product list
        /// </summary>
        /// <returns>List of products</returns>
        public override List<Product> Deserialize()
        {
            {
                try
                {
                    //Get the raw string
                    string yamlString = File.ReadAllText(ResourcePath);

                    //Load the stream
                    var yamlStream = new YamlStream();
                    yamlStream.Load(new StringReader(yamlString));

                    //Deserialize the document
                    YamlSequenceNode nodes = (YamlSequenceNode)yamlStream.Documents[0].RootNode;

                    List<Product> products = new List<Product>();
                    foreach (YamlMappingNode item in nodes)
                    {
                        Product product = new Product();
                        product.Categories = ((YamlScalarNode) item.Children["tags"]).Value;
                        product.Name = ((YamlScalarNode) item.Children["name"]).Value;
                        product.Twitter = ((YamlScalarNode)item.Children["twitter"]).Value;
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
}
