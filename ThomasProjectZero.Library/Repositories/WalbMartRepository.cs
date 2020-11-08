using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;

namespace ThomasProjectZero.Library.Repositories
{
    public class WalbMartRepository 
    {
        //We'll just focus on customers for now, and keep figuring this out.
        //Protocode for reading in data for the WalbMarts
        private readonly ICollection<WalbMart> _data;

        public WalbMartRepository(ICollection<WalbMart> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }
        //Search through WalbMarts for product
        public IEnumerable<WalbMart.Products> WalbMartProductSearch(string search)
        {
            if (search == null)
            {
                foreach (var wb in _data)
                {
                    yield return wb;
                }
            }

            if (search != null)
            {
                foreach (var wb in _data.Where(i => i.WalbMart.Products.Contains(search) && i.WalbMart.Products.Stock.Contains(search) > 0))
                {
                    yield return wb;
                }
            }

            else
            {
                break;
            }
        }


        //Still need to read in products from data and populate the
        //current stock of each WalbMart with data
        public StockWalbMartProducts()
        {
            //code goes here
        }   

        public 

    }
}