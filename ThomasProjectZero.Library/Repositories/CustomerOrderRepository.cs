using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;

namespace ThomasProjectZero.Library.Repositories
{
    public class CustomerOrderServices
    {
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
            Console.WriteLine(Customer.GetOrderHistory());
        }

        //Still need to read in data and populate the current customers
        //And initialize those customers with their order history
    }
}
