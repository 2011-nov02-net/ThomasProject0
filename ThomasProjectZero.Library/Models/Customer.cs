using System;
using System.Collections.Generic;
using System.Linq;

namespace ThomasProjectZero.Library.Models
{
    public class Customer
    {
        private string _customerFullName
        
        public string CustomerFullName
        {
            get => _customerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //error checking
                    throw new ArgumentException(message: "invalid name", paramName: nameof(value));
                }
                _customerName = value.
            } 
        }
        //To prevent errors and so forth when searching to being capital sensitive
        var _customerName = _customerName.trim().toUpperCase();

        public List<Order> Orders { get; set; } = new List<Order>();

        //will need to read in information from the customer class object, 
        //the Datetime class to produce a time stamp, and the current stock of a given product 
        //at the target location of a given instance of WalbMart.
        public void PlaceOrder(string customerFullName, string locationOfPurchase, string productName, int quanitityOfPurchase, double costOfPurchase, DateTime date, int walbMartCurrentStockOfProduct)
        {
            if (walbMartCurrentStockOfProduct >= quanitityOfPurchase && quanitityOfPurchase > 0)
            {
                Console.WriteLine("Customer: " + nameof(customerFullName));
                Console.WriteLine("Has purchased:  x" + nameof(quantityOfPurchase) + " " nameof(productName));
                Console.WriteLine("At WalbMart: " + nameof(locationOfPurchase)); 
                Console.WriteLine("Date of Purchase: " + nameof(date));
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(quanitityOfPurchase), "You didn't buy anything");
                break;
            }
            var order = new Order(customerFullName, locationOfPurchase, productName, quanitityOfPurchase, costOfPurchase, date);
            Orders.Add(order);
        }


    }
}