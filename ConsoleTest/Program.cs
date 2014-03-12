using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortAlgorithmLib;
using SortAlgorithmLib.ExchangeSort;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ls = new List<int> { 6, 5, 3, 4, 2 };
            List<int> ls1 = new List<int> { 6, 4, 3, 3, 2, 2, 11, 23, 324 };
            IntSortManager ism = new IntSortManager();

            foreach (var item in ism.BubbleSortList(ls, SortDirection.DESC))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------------");
            foreach (var item in ism.BubbleSortList(ls1))
            {
                Console.WriteLine(item);
            };
            Console.ReadKey();
        }
    }
}
