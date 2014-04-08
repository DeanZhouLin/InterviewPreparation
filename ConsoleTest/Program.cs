using System;
using System.Collections.Generic;
using SortAlgorithmLib;

namespace ConsoleTest
{
    class Program
    {
        static readonly List<Student> sLs = new List<Student>
            {
                new Student("周林",1.2,1.98),
                new Student("wangaihua",3,1.65),
                new Student("jkj",2,1.68),
                new Student("jew",1.12,1.78)
            };

        static void Main(string[] args)
        {
            DoubleSortManager<Student> sm = new DoubleSortManager<Student>(i => i.Height)
            {
                SortBase = new HeapSort<double, Student>()
            };

            sm.SortBase = new SelectionSort<double, Student>();

            foreach (var item in sm.Sort(sLs))
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
