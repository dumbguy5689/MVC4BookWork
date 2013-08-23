using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        //The this keyword in front of the first parameter marks TotalPrices as an extension method. The first
        //parameter tells .NET which class the extension method can be applied to—ShoppingCart in our case.
        public static decimal TotalPrices(this ShoppingCart cardParam)
        {
            decimal total = 0;
            foreach (Product prod in cardParam.Products) { total += prod.Price; }
            return total;
        }//public static decimal TotalPrices(this ShoppingCart cardParam)

        public static decimal TotalPrices(this IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in productEnum)
            {
                total += prod.Price;
            }
            return total;
        }//public static decimal TotalPrices(this IEnumerable<Product> productEnum)


        public static IEnumerable<Product> FilterByCategory( this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }//public static IEnumerable<Product> FilterByCategory( this IEnumerable<Product> productEnum, string categoryParam)

        public static IEnumerable<Product> Filter( this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }//public static IEnumerable<Product> Filter( this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)

    }//public static class MyExtensionMethods
}