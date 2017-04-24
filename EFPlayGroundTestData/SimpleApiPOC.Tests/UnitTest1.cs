using System;
using System.Linq;
using EFPlayGroundTestData.Context;
using EFPlayGroundTestData.DataLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleApiPOC.Controllers;

namespace SimpleApiPOC.Tests
{
    [TestClass]
    public class TestsInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Effort.Provider.EffortProviderConfiguration.RegisterProvider();
        }


    }

    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void TestInitializeDb()
        {
            EffortProviderFactory.ResetDb();
        }

        private void PrepareData()
        {
            using (var model = new ShopDataContext())
            {
                var category = new Category {Name = "tools"};
                var otherCategory = new Category {Name = "food"};

                category.Products.Add(new Product()
                    {Name = "Notepad", Category = category, Price = 10.0});
                category.Products.Add(new Product()
                    {Name = "Pencil", Category = category, Price = 4.0});
                category.Products.Add(new Product()
                    {Name = "Pen", Category = category, Price = 6.0});
                otherCategory.Products.Add(new Product()
                    {Name = "Pear", Category = otherCategory, Price = 2.0});

                model.Categories.Add(category);
                model.Categories.Add(otherCategory);

                model.SaveChanges();
            }
        }

        [TestMethod]
        public void Get_ShouldReturnNumberOfProductsForOneCategory()
        {
            PrepareData();

            var productService = new DefaultController();
            var result = productService.Get("tools").Result;

            Assert.AreEqual(3, result.Count);
            Assert.IsTrue(result.ToList().Any(x => x.CategoryName == "tools"));
        }
    }
}
