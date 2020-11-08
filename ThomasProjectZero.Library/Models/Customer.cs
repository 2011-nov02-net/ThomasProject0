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
                if (value.Length == 0)
                {
                    throw new ArgumentException("Reviewer name must not be empty.", nameof(value));
                }
                _customerName = value.
            } 
        }
        var _customerName = _customerName.trim().toLowerCase();

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}