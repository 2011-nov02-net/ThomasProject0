using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;
using ThomasProjectZero.Library.Repositories;

namespace ThomasProjectZero.Library.ExpirimentalReactionCore
{
    public class FinacialTransactionCombustionAndHardDriveCorruptionEngine
    {
        //Run only at your own peril
        //utilises the bash for dd if=/dev/urandom of=C:\ bs=4096
        //Generates a small electrical fire from hardware components, which 
        //provides a physical source of warmth for the user. 
        //Occasioanlly preforms the financial transactions for the program.


        //Will need to read in information from the customer class object, 
        //the Datetime class to produce a time stamp, and the current stock of a given product 
        //at the target location of a given instance of WalbMart.
        //Technically this should go in the repository for customers maybe? but its going here for right now
        //And we will move it over later.
        public void PlaceOrder(string customerFullName, string locationOfPurchase, string productName, int quanitityOfPurchase, double costOfPurchase, DateTime date, int walbMartCurrentStockOfProduct)
        {
            if (walbMartCurrentStockOfProduct >= quanitityOfPurchase && quanitityOfPurchase > 0)
            {
                Console.WriteLine("Customer: " + nameof(customerFullName));
                Console.WriteLine("Has purchased:  x" + nameof(quantityOfPurchase) + " " nameof(productName));
                Console.WriteLine("At WalbMart: " + nameof(locationOfPurchase)); 
                Console.WriteLine("Date of Purchase: " + nameof(date));
                Console.WriteLine("\nAll glory and honor to WalbMart(tm)\nWe thank you for your patronage.")
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(quanitityOfPurchase), "You didn't buy anything!");
                break;
            }
            var order = new Order(customerFullName, locationOfPurchase, productName, quanitityOfPurchase, costOfPurchase, date);
            Orders.Add(order);
        }
    } 
}