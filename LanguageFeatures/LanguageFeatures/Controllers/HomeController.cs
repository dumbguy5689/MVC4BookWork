using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LanguageFeatures.Models;


namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }//public string Index()

        public ViewResult AutoProperty()
        {
            ////create a new Product object
            //Product myProduct = new Product();

            ////set the property value
            //myProduct.Name = "Kayak";

            ////get the property
            //string productName = myProduct.Name;

            // create and populate a new Product object
            Product myProduct = new Product
            {
                ProductID = 100,
                Name = "Kayak",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            //generate the view
            return View("Result", (object)String.Format("Category: {0}", myProduct.Category));

        }//public ViewResult AutoProperty()

        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
                }
            };
            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();
            return View("Result",
            (object)String.Format("Total: {0:c}", cartTotal));
        }//public ViewResult UseExtension()

        public ViewResult UseExtensionEnumerable()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                    }
                };
            // create and populate an array of Product objects
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };
            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();
            return View("Result",
            (object)String.Format("Cart Total: {0}, Array Total: {1}",
            cartTotal, arrayTotal));
        }//public ViewResult UseExtensionEnumerable()


        public ViewResult UseFilterExtensionMethod()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports",
                Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer",
                Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer",
                Price = 34.95M}
                }
            };
            decimal total = 0;

            //Func<Product, bool> categoryFilter = prod => prod.Category == "Soccer";

            //foreach (Product prod in products.FilterByCategory("Soccer"))
            foreach (Product prod in products.Filter(prod => prod.Category == "Soccer"))
            {
                total += prod.Price;
            }
            return View("Filtered Total Result", (object)String.Format("Total: {0}", total));
        }//public ViewResult UseFilterExtensionMethod()

    }//public class HomeController : Controller
}
