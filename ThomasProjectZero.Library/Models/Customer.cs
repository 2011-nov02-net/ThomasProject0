using System;
using System.Collections.Generic;
using System.Linq;

namespace ThomasProjectZero.Library.Models
{
    public class Customer
    {
        private string _customerFullName;
        
        public string CustomerFullName
        {
            get => _customerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //error checking
                    throw new ArgumentException(message: "invalid name, stop breaking things", paramName: nameof(value));
                }
                _customerName = value.
            } 
        }
        //To prevent errors and so forth when searching to being capital sensitive
        var _customerName = _customerName.trim().toUpperCase();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}