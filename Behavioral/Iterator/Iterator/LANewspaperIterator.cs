using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator.Iterator
{
    public class LANewspaperIterator: IIterator
    {
        private string[] _reporters;
        private int _current;
        public LANewspaperIterator(string[] reporters)
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
            return _current >= _reporters.Length;
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
