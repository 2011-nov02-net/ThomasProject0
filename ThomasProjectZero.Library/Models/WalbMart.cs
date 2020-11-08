using System;
using System.Collections.Generic;
using System.Linq;

namespace ThomasProjectZero.Library.Models
{
    public class WalbMart
    {
        private string _location

        public int Id { get; set;}

        public string Location
        {
            get => _location;
            
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _name = value;
            }
        }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}