using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterator
{
    public class NYNewspaperIterator : IIterator
    {

        private List<string> _reporters;
        private int _current;
        public NYNewspaperIterator(List<string> reporters)
        {
            _reporters = reporters;
            _current = 0;
        }

        public string CurrentItem()
        {
            return _reporters[_current];
        }

        public bool Done()
        {
            return _current >= _reporters.Count;
        }

        public void First()
        {
            _current = 0;
        }

        public string Next()
        {
            return _reporters[_current++];
        }
    }
}
