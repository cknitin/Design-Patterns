using Iterator.Aggregate;
using Iterator.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            INewspaper ny = new NYNewspaper();
            INewspaper la = new LANewspaper();

            IIterator nyItr = ny.CreateIterator();
            IIterator laItr = la.CreateIterator();

            Console.WriteLine("----- NY ");
            PrintReporter(nyItr);

            Console.WriteLine("----- LA ");
            PrintReporter(laItr);

            Console.ReadLine();
        }

        public static void PrintReporter(IIterator iterator)
        {
            iterator.First();

            while (!iterator.Done())
            {
                Console.WriteLine(iterator.Next());
            }
        }
    }
}
