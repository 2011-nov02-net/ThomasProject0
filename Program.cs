using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThomasProject0
{
    class Program
    {
        static void Main(string[] args)
        {
            //create test WalbMart
            //::Some random useless code::
            //string testAddress = "162 Wharf Ave, Somewhere, NJ, 12345";
            //var testWalbmart = new WalbMart(testAddress);
            //var testWalbMart = new Dictonary<string, List<ProductDetails>>()

            var Products = new Product[4];

            Products[0] = new Product();
            Products[0].ProductLocation= "162 Wharf Ave, Candy Land, NJ, 12345";
            Products[0].ProductName = "poop";
            Products[0].ProductPrice = 10.00;
            Products[0].ProductStock = 100;
            Products[1] = new Product();
            Products[1].ProductLocation = "Nowhere Nova Scotia, the angriest pinecone blvd, Canada";
            Products[1].ProductName = "Units of corregated paper board";
            Products[1].ProductPrice = 1.50;
            Products[1].ProductStock = 6000;
            Products[2] = new Product();
            Products[2].ProductLocation = "Neptune, somewhere beyond the orbit of Saturn";
            Products[2].ProductName = "Jeff";
            Products[2].ProductPrice = 9.35;
            Products[2].ProductStock = 1;
            Products[3] = new Product();
            Products[3].ProductLocation = "Neptune, somewhere beyond the orbit of Saturn";
            Products[3].ProductName = "Graham Crackers";
            Products[3].ProductPrice = 6.00;
            Products[3].ProductStock = 200;

            var testWalbMart = new WalbMart();
            testWalbMart.WalbMartLocation = "timbucktoo buck ave";

        }
    }
}