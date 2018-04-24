using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=4, b=2;
            var (explanation, binAnswer, answer) = BothMultipl.Multiply(a,b);
            Console.WriteLine("a=" + a + " b=" + b);
            Console.WriteLine("c=a*b");
            Console.WriteLine("В десятковій c="+answer);
            //Console.WriteLine("В двійковій с=" + binAnswer);
            Console.WriteLine("=======================================================");
            Console.WriteLine(explanation);
            Console.ReadLine();
        }
    }
}
