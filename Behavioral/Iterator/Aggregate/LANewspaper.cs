using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Aggregate
{
    public class LANewspaper : INewspaper
    {
        private string[] _reporters;

        public LANewspaper()
        {
            _reporters = new[] {
                "Bruce Wyan -LA",
                "Kent Clark-LA"
            };
        }

        public IIterator CreateIterator()
        {
            return new LANewspaperIterator(_reporters); 
        }
    }
}
