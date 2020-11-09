using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Proj0XmlSerializer
{
    [XmlRootAttribute("PurchaseOrder", IsNullable = false)]
    public class PurchaseOrder
    {
        public Customer _guyWhoBoughtStuff;

        /* The XmlArrayAttribute changes the XML element name
        from the default of "OrderedItems" to "Items". */
        [XmlArrayAttribute("Items")]
        public OrderedProduct[] OrderedProducts;
        public double TotalCost;
    }
    public class OrderedProduct
    {
        private string _customerName;
        private string _locationOfPurchase;
        private string _productName;
        private int _quanitityOfPurchase;
        private double _costOfUnitPurchase;
        private double _timeOfPurchase;   

        //_totalCostOfProduct is not passed in, but is calculated through a method.
        private double _totalCostOfProduct;

        public OrderedProduct(string Cn = "", string Lop = "", string Pn = "", int Qop = 0, double Coup = 0, double Top =0)
        {
            Cn = _customerName;
            Lop = _locationOfPurchase;
            Pn = _productName;
            Qop = _quanitityOfPurchase;
            Coup = _costOfUnitPurchase;
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

        public double CostOfUnitPurchase
        {
            get { return _costOfUnitPurchase; }
            set { _costOfUnitPurchase = value; }
        }

        public double TimeOfPurchase
        {
            get {  return _timeOfPurchase; }
            set { _timeOfPurchase = value;}
        }

        public double TotalCostOfProduct
        {
            get {  return _totalCostOfProduct; }
            set { _totalCostOfProduct = _totalCostOfProduct = _costOfUnitPurchase * _quanitityOfPurchase;}
        }
    }

    public class Customer
    {
        [XmlElementAttribute(IsNullable = false)]
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //error checking
                    throw new ArgumentException(message: "invalid name, stop breaking things", paramName: nameof(value));
                }
                var _customerName = value.Trim().ToUpper();
            } 
        }
        //To prevent errors and so forth when searching to being capital sensitive
        public List<PurchaseOrder> Orders { get; set; } = new List<PurchaseOrder>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public void AddOrderToPlaceOrder(string customerFullName, string locationOfPurchase, string productName, int quanitityOfPurchase, double costOfPurchase, DateTime date, int walbMartCurrentStockOfProduct, PurchaseOrder purchaseorder)
        {
            if (walbMartCurrentStockOfProduct >= quanitityOfPurchase && quanitityOfPurchase > 0)
            {
            var order = new OrderedProduct(customerFullName, locationOfPurchase, productName, quanitityOfPurchase, costOfPurchase);
            var puorder = purchaseorder;
            OrderedProduct [] items = purchaseorder.OrderedProducts;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(quanitityOfPurchase), "You didn't buy anything!");
            }
            if (purchaseorder == null)
            {

            }


        }
        
        private void SerialNewProductOrder(string FileName, Customer customer, PurchaseOrder purchaseorder)
        {
            //initialize the XML Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));
            TextWriter writer = new StreamWriter(FileName);
            //boxing for data serialization
            //Creates a local objects of the passed customer/purchase order
            //references 
            Customer c = new Customer();
            c = customer;
            PurchaseOrder p = new PurchaseOrder();
            p = purchaseorder;

            OrderedProduct OP = new OrderedProduct();
            OrderedProduct [] items = {OP};
            p.OrderedProducts = items;

            double subTotal = new double();
            foreach(OrderedProduct oi in items)
            {
                 p.TotalCost += oi.TotalCostOfProduct;
            }
            p.TotalCost = subTotal;

            // Serialize the purchase order, and close the TextWriter.
            serializer.Serialize(writer, p);
            writer.Close();
        }
    }
}
