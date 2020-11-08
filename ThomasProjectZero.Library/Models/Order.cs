using System;
using System.Collections.Generic;
using System.Linq;

namespace ThomasProjectZero.Library.Models
{
    public class Order
    {
        private string _customerName;
        private string _locationOfPurchase;
        private string _productName;
        private int _quanitityOfPurchase;
        private double _costOfPurchase;
        private double _timeOfPurchase;   

        public Order(string Cn = "", string Lop = "", string Pn = "", int Qop = 0, double Cop = 0, double Top =0)
        {
            Cn = _customerName;
            Lop = _locationOfPurchase;
            Pn = _productName;
            Pa = _quanitityOfPurchase;
            Cop = _costOfPurchase;
            Top = _timeOfPurchase;
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public string LocationOfPurchase
        {
            get { return _locationOfPurchase; }
            set { _locationOfPurchase = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int QuanitityOfPurchase
        {
            get { return _quanitityOfPurchase; }
            set { _quanitityOfPurchase = value; }
        }

        public double CostOfPurchase
        {
            get { return _costOfPurchase; }
            set { _costOfPurchase = value; }
        }

        public double TimeOfPurchase
        {
            get {  return _timeOfPurchase; }
            set { _timeOfPurchase = value;}
        }

    }
}