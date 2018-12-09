using System;
using System.Collections.Generic;
using ProductAssignment.Importers;
using System.Configuration;

namespace ProductAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductImporter> providers = new List<ProductImporter>();

#if DEBUG
            FillAllProviders(providers);
#else
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string resourcePath = args[i];
                    Console.WriteLine(resourcePath);
                    if (resourcePath.EndsWith(".yaml"))
                    {
                        providers.Add(new CapterraImporter(resourcePath));
                    }
                    else if (resourcePath.EndsWith(".json"))
                    {
                        providers.Add(new SoftwareAdviceImporter(resourcePath));
                    }
                    else
                    {
                        Console.Write("The extension is not supported");
                    }

                }

            }
            else
            {
                Console.WriteLine("Please provide at least one source argument");
                return;
            }
#endif
            ImportProducts(providers);
            Console.ReadKey();

        }

        /// <summary>
        /// Use the list of providers to do the actual import
        /// </summary>
        /// <param name="importers"></param>
        private static void ImportProducts(List<ProductImporter> providers)
        {
            foreach (var importer in providers)
            {
                List<Product> products = importer.Deserialize();
                if (products != null)
                {
                    Console.WriteLine($"Importing from {importer.ResourcePath}...");
                    if (!importer.PersistData(products))
                    {
                        Console.WriteLine($"An error occurred while importing from {importer.ResourcePath}...");
                        Console.WriteLine("See error log for more information");
                    }
                }
                else
                {
                    Console.WriteLine($"Importer {importer.GetType().Name} did not yield any results");
                }
            }
            Console.WriteLine("Import products ended");
        }


        private static void FillAllProviders(List<ProductImporter> providers)
        {
            providers.Add(new SoftwareAdviceImporter("../../feed-products/softwareadvice.json"));
            providers.Add(new CapterraImporter("../../feed-products/capterra.yaml"));
        }

    }
}
