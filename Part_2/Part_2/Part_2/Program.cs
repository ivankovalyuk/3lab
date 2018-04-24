using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 20;
            int b = 3;
            Console.WriteLine("a="+a+"\nb="+b+"\n");
            var (explanation, remainder, quotient) = Divis.Divide(a, b);
            Console.WriteLine("quotient"+quotient);
            Console.WriteLine("remainder"+remainder);
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine(explanation);
            Console.ReadLine();
        }
    }
}
