using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lambda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var data = new int[] { 1, 5, 9, 14 };

            Console.WriteLine("Original array:");
            Print(data);

            // calling function Map with data and a function written with lambda expression
            var newData = Map(data, y => y + 1);
            Console.WriteLine();
            Console.WriteLine("New array with values one more than original:");
            Print(newData);
        }

        // create function MAp that receives the data array and the function f;
        // f is written with genereic delegate type that takes an int as input and returns an int
        public static int[] Map(int[] a, Func<int, int> f)
        {
            var res = new int[a.Length];

            for (var i = 0; i < a.Length; i++)
            {
                // using the function f that takes one input integer and returns an int
                res[i] = f(a[i]);
            }

            return res;
        }

        public static void Print(int[] a)
        {
            foreach (var i in a)
            {
                Console.WriteLine(i);
            }
        }
    }
}
