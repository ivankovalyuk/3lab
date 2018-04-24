using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
namespace Part_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            float a= 70.5F, b=-46.5F;
            var( def, binAnsw,result) =FloatPointSum.Add(a, b);
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Result Binary: " + binAnsw);
            Console.WriteLine("=====================================");
            Console.WriteLine(def);

            Console.ReadLine();
        }
    }
}
