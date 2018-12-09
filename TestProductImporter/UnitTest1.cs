using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAssignment;
using ProductAssignment.Importers;

namespace TestProductImporter
{
    [TestClass]
    public class TestProvider
    {
        const string workingDirectory = @"C:\Users\yuval\Source\Repos\ProductAssignment\feed-products";
        [TestMethod]
        public void TestCapterraImporter_Deserialization()
        {
            string path = Path.Combine(workingDirectory, "capterra.yaml");
            ProductImporter productImporter = new CapterraImporter(path);
            List<Product> products = productImporter.Deserialize();
            Assert.IsNotNull(products);

        }


        [TestMethod]
        public void TestSoftwareAdviceImporter_Deserialization()
        {
            string path = Path.Combine(workingDirectory, "softwareadvice.json");
            ProductImporter productImporter = new SoftwareAdviceImporter(path);
            List<Product> products = productImporter.Deserialize();
            Assert.IsNotNull(products);

        }


        [TestMethod]
        public void TestCapterraImporter_PersistData()
        {
            string path = Path.Combine(workingDirectory, "capterra.yaml");
            ProductImporter productImporter = new CapterraImporter(path);
            List<Product> products = productImporter.Deserialize();
            Assert.IsTrue(productImporter.PersistData(products));

        }

        [TestMethod]
        public void TestSoftwareAdviceImporter_PersistData()
        {
            string path = Path.Combine(workingDirectory, "softwareadvice.json");
            ProductImporter productImporter = new SoftwareAdviceImporter(path);
            List<Product> products = productImporter.Deserialize();
            Assert.IsTrue(productImporter.PersistData(products));

        }

    }
}
