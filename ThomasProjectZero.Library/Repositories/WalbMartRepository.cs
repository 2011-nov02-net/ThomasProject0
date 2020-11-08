using System;
using System.Collections.Generic;
using System.Linq;
using ThomasProjectZero.Library.Models;

namespace ThomasProjectZero.Library.Repositories
{
    public class WalbMartRepository 
    {
        //We'll just focus on customers for now, and keep figuring this out.
        //Stuff for reading in data for the WalbMarts
        private readonly ICollection<WalbMart> _data;

        public WalbMartRepository(ICollection<WalbMart> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public IEnumerable<Walbmat> WalbMarts(string search = null)
        {
            if (search == null)
            {
                foreach (var wb in _data)
                {
                    yield return wb;
                }
            }
            else
            {
                foreach (var wb in _data.Where(i => i.WalbMartLocation.Contains(search)))
                {
                    yield return wb;
                }
            }
        }

    }
}