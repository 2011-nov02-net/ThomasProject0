using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Proj0
{
    [XmlRootAttribute("PurchaseOrder", IsNullable = false)]
    public class PurchaseOrder
    {
        public Customer _guyWhoBoughtStuff;
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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

        public void SerializeCustomerData(String FileName, Customer customer)
        {
            //initialize the XML Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(Customer));
            TextWriter writer = new StreamWriter(FileName);
            //boxing for data serialization
            //Creates a local objects of the passed customer/purchase order
            //references 
            Customer c = new Customer();
            c = customer;
            // Serialize the purchase order, and close the TextWriter.
            serializer.Serialize(writer, c);
            writer.Close();
        }
    }

    public class SaveData
    {
        public void SerializeProductOrderData(string FileName, PurchaseOrder purchaseorder)
        {
            //initialize the XML Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(PurchaseOrder));
            TextWriter writer = new StreamWriter(FileName);
            //boxing for data serialization
            //Creates a local objects of the passed customer/purchase order
            //references 
            PurchaseOrder p = new PurchaseOrder();
            p = purchaseorder;

            OrderedProduct OP = new OrderedProduct();
            OrderedProduct [] items = {OP};
            p.OrderedProducts = items;

            double Total = new double();
            foreach(OrderedProduct oi in items)
            {
                p.TotalCost += oi.TotalCostOfProduct;
            }
            p.TotalCost = Total;

            // Serialize the purchase order, and close the TextWriter.
            serializer.Serialize(writer, p);
            writer.Close();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var datasource = new List<PurchaseOrder>();
            var serializer = new XmlSerializer(typeof(List<PurchaseOrder>));
            var datasource2 = new List<Customer>();
            var serializer2 = new XmlSerializer(typeof(List<Customer>));
            
            while (true)
            {
                Console.WriteLine("Welcome to WalbMart, gib us all da monies.");
                Console.WriteLine("Remember that all sales are final!");
                Console.WriteLine("a:\tAdd new customer");
                Console.WriteLine("s:\tView customer's order history.");
                Console.WriteLine("d:\tSearch for WalbMart Products");
                Console.WriteLine("z:\tSave Data");
                Console.WriteLine("x:\tLoad customer and product data from disk.");
                Console.WriteLine("f:\tQuit.");
                Console.WriteLine();
                var input = Console.ReadLine();
                
                if (input == "a")
                {
                    var customer = new Customer();
                    while (customer.CustomerName == null)
                    {
                        Console.WriteLine();
                        Console.Write("Enter the new customer's name: ");
                        input = Console.ReadLine();
                        try
                        {
                            customer.CustomerName = input;
                        }
                        catch (ArgumentException burp)
                        {
                            Console.WriteLine(burp.Message);
                        }
                    }
                    datasource2.Add(customer);
                    Console.WriteLine();
                    customer.SerializeCustomerData("customerdata.xml", customer);
                    Console.WriteLine("Customer "+customer.CustomerName+" has been added and saved to file.");
                }
                else if (input == "d")
                {
                    Console.WriteLine("d:\tHere is the list of available products.");
                    //List available products
                    Console.WriteLine();
                    Console.WriteLine("Choose a product to find a WalbMart location to place your order from!");
                    //print the list of current WalbMart locations which feature the product
                    Console.WriteLine();
                }
                
            }
        }

        IEnumerable<Customer> GetCustomers(string search = null)
        {
            var datasource2 = new List<Customer>();
            if (search == null)
            {
                foreach (var item in datasource2)
                {
                yield return item;
                }
            }
            else
            {
                foreach (var item in datasource2.Where(r => r.CustomerName.Contains(search)))
                {
                    yield return item;
                }
            }
        }


        static void GeneratePurchaseOrders(ICollection<PurchaseOrder> data)
        {
            data = data ?? throw new ArgumentNullException(nameof(data));
        }

        static void GenerateCustomers(ICollection<Customer> data2)
        {
            data2 = data2 ?? throw new ArgumentNullException(nameof(data2));
        }

        //Customer GetCustomerByCustomerFullName(string CustomerName)
        //{
            //return data2.First(i => i.CustomerName == CustomerName);
        //}


        void AddOrderToPlaceOrder(string customerFullName, string locationOfPurchase, string productName, int quanitityOfPurchase, double costOfPurchase, DateTime date, int walbMartCurrentStockOfProduct, PurchaseOrder purchaseorder)
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
    }
}