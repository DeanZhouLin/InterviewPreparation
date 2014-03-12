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
            IntSortManager ism = new IntSortManager();
            var res = ism.BubbleSortList(ls, SortDirection.DESC);
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("------------------------------");

            List<Student> sLs = new List<Student>
            {
                new Student("周林",1.2,1.98),
                new Student("wangaihua",3,1.65),
                new Student("jkj",2,1.68),
                new Student("jew",1.12,1.78)
            };
            SortManager<double, Student> sm = new SortManager<double, Student>(i => i.Age, (x, y) => (int)((x - y)*100));
            var res1 = sm.BubbleSortList(sLs);
            foreach (var item in res1)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("------------------------------");
            sm.GetSortFieldFunc = i => i.Height;
            res1 = sm.BubbleSortList(sLs);
            foreach (var item in res1)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public double Age { get; set; }
        public double Height { get; set; }

        public Student(string name, double age, double height)
        {
            Name = name;
            Age = age;
            Height = height;
        }

        public override string ToString()
        {
            return Name + "-" + Age + "-" + Height;
        }
    }
}
