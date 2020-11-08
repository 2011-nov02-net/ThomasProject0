using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;

namespace ThomasProjectZero.Library.Repositories
{
    public class CustomerOrderRepository
    {
        //No clue if I should have two seperate repositories here
        //one for the "WalbMarts" and the other for customer data,
        //but it makes enough sense in my head to do it this way.
        //They're distinct enough to warrant somekind of seperation.
        private readonly ICollection<Customer> _data;
        
        public CustomerRepository(ICollection<Customer> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public Customer GetCustomerByCustomerFullFame(string customerFullName)
        {
            return _data.First(i => i.CustomerFullName == customerFullName);
        }

        public void AddCustomer(Customer customer)
        {
            if (_data.Any(i => i.customer.CustomerFullName))
            {
                throw new InvalidOperationException($"You are an imposter! Customer with name {customer.CustomerFullName} already exists.");
                break;
            }
            _data.Add(customer);
        }

        //functions for Customer Menu options
        public void MenuFunctionsCustomer(Customer customer)
        {
            AddCustomer(customer);
            SearchCustomerHistory(customer);
        }


        //Acquire timestamp for a customer's order at time of purchase
        //Obsolete probably doesn't work
        //public static String GetTimestamp(DateTime value)
        //{
        //    return value.ToString("yyyyMMddHHmmssffff");
        //}

        public void PlaceOrder(string customerName, DateTime date, string note)
        {
            if (moneyAmount <= 0)
            {
                Console.WriteLine(nameof(moneyAmount)); // prints "moneyAmount"
                Console.WriteLine("amount"); // prints "amount"
                Console.WriteLine(moneyAmount); // prints amount (e.g. 25.0)
                throw new ArgumentOutOfRangeException(nameof(moneyAmount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(moneyAmount, date, note);
            allTransactions.Add(deposit);
        }
        //Adds order to a customer's order history and attaches a time stamp to it.
        //There are competing functions now, in different files, need to figure which ones work better
        public void AddOrderToCustomerHistory(Order orders, Customer customer)
        {
            DateTime saveUtcNow = DateTime.UtcNow;
            DateTime myDate = DateTime.SpecifyKind(saveUtcNow, DateTimeKind.Utc);
            customer.Orders.Add(orders => this.customer.Order.TimeOfPurchase = myDate);
            //Maybe this is wrong
            //could try this instead
            //customer.Orders.Add(orders, myDate);
            //Or this
            //this.customer.Order.TimeOfPurchase = myDate;
            //Err... No, I think not. I don't think inheritence works this way.
            //This data is getting passed around to too many places, its confusing.
            //And likely I'm reduntantly storing too much data
            //Maybe I should implement somekind of dictonary to simplify things.
            //If only I knew how to.
        }

        public string GetOrderHistory()
        {
            var goh = new System.Text.StringBuilder();

            goh.AppendLine("Customer\t\tWalbMart Location\tProduct:\tCost\t");
            
            foreach (var order in allTransactions)
            {
                report.AppendLine($"{order.CustomerName}\t{order.LocationOfPurchase}\t{order.ProductName}\t{order.CostOfPurchase}\t{order.TimeOfPurchase.ToShortDateString()}");
            }

            return report.ToString();
        }

        public string PrintOrderHistory()
        {
            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
