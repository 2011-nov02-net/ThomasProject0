using System;
using System.Collections.Generic;
using System.Linq;

namespace ThomasProjectZero.Library.Models
{
    public class Product
    {
        //Its redundant to store the location name, but were doing it anyway.
        //Just for tracking and testing purposes later on.
        private string _location;
        private string _productName;
        private double _cost;
        private int _stock;

        public Product(string Loc = "", string Pro = "", double Pri = 0, int Stk = 0)
        {
            Loc = _location;
            Pro = _product;
            Pri = _cost;
            Stk = _stock;
        }

        public string Location
        {
            get { return location; }
            set { _location = value; }
        }

        public string ProductName
        {
            get { return product; }
            set { _product = value; }
        }

        public double Price
        {
            get { return cost; }
            set { _cost = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { _stock = value; }
        }
    }
}