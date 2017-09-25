using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigleySequenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type exit to quit");
            try
            {
                while (true)
                {
                    Console.WriteLine("Enter number");
                    string line = Console.ReadLine();
                    if (line == "exit")
                    {
                        break;
                    }
                    int num;
                    if (int.TryParse(line, out num))
                    {
                        Console.WriteLine("Higley Sequence Sum => " + Enumerable.Range(1, num).Sum(x => GetHigleySequence(x)));
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        private static int GetHigleySequence(int n)
        {
            List<int> list = new List<int>();
            while (!list.Contains(n))
            {
                list.Add(n);
                n = GetHigley(n);
            }
            return list.Count;
        }

        private static int GetHigley(int n)
        {
            if (n > 1)
            {
                IEnumerable<int> primeFactors = GetPrimeFactors(n);
                return primeFactors.Sum(x => x) * primeFactors.Count();
            }
            else { return 0; }
        }

        public static IEnumerable<int> GetPrimeFactors(int number)
        {
            int loop = (int)Math.Sqrt(number);
            int first = Enumerable.Range(2, loop)
                .Where(x => Enumerable.Range(2, x - 2).All(y => x % y != 0))
                .FirstOrDefault(x => number % x == 0);
            return first == 0 || first == number
                ? new[] { number }
                    : new[] { first }.Concat(GetPrimeFactors(number / first));
        }

    }

}
