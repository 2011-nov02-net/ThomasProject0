using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThomasProject0
{
    public class Product
    {
        private string location;
        private string product;
        private double cost;
        private int stock;

        public Product(string Loc = "", string Pro = "", double Pri = 0, int Stk = 0)
        {
            Loc = location;
            Pro = product;
            Pri = cost;
            Stk = stock;
        }

        public string ProductLocation
        {
            get { return location; }
            set { location = value; }
        }

        public string ProductName
        {
            get { return product; }
            set { product = value; }
        }

        public double ProductPrice
        {
            get { return cost; }
            set { cost = value; }
        }

        public int ProductStock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}