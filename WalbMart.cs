using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThomasProject0
{
    public class WalbMart 
    {
        private string location;

        public WalbMart(string Loc = "")
        {
            Loc = location;
        }
        public string WalbMartLocation
        {
            get { return location; }
            set { location = value; }
        }
    }
}