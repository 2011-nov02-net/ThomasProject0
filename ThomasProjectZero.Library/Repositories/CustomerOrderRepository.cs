using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;

namespace ThomasProjectZero.Library.Repositories
{
    public class CustomerOrderRepository
    {
        //No clue if I should have two seperate repositories here
        //one for the "WalbMarts and the other for customer data,
        //but it makes enough sense in my head to do it this way.
        //They're distinct enough to warrant somekind of seperation.
        private readonly ICollection<Customer> _data;
        
        public CustomerRepository(ICollection<Customer> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public Customer GetCustomerByCustomerFullFame(string customerFullName)
        {
            return _data.First(r => r.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            if (_data.Any(r => r. == customer.CustomerFullName))
            {
                throw new InvalidOperationException($"Customer with ID {customer.CustomerFullName} already exists.");
            }
            _data.Add(customer);
        }

        //functions for Customer Menu options
        public void UpdateCustomer(Customer customer)
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
        public void AddOrderToCustomerHistory(Order orders, Customer customer)
        {
            DateTime saveUtcNow = DateTime.UtcNow;
            DateTime myDate = DateTime.SpecifyKind(saveUtcNow, DateTimeKind.Utc);
            customer.Orders.Add(orders => this.customer.Order.TimeOfPurchase = myDate;);
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
        
    }


}