using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Aggregate
{
    public class NYNewspaper : INewspaper
    {
        private List<string> _reporters;
        public NYNewspaper()
        {
            _reporters = new List<string>
            {
                "Peter Parker - NY",
                "Marry Jane - NY"
            };
        }

        public IIterator CreateIterator()
        {
            return new NYNewspaperIterator(_reporters);
        }
    }
}
