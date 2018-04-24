using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_2
{
    class Divis
    {
        public static (string explanation, int remainder, int quotient) Divide(int divident, int divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException();
            string exp = "";
            int a = Math.Abs(divident), b = Math.Abs(divisor);
            int q = 0, r = 0;
            if (a < b)
            {
                r = divident;
                exp += "Ділене менше за дільник, тому остача = діленому\n";
            }
            else
            {
                exp += $"{Convert.ToString(a, 2)} mod divident\n";
                exp += $"{Convert.ToString(b, 2)} mod divisor\n\n";
                int lenA, lenB, k;
                int tmp = a;
                for (lenA = 0; tmp != 0; tmp >>= 1, lenA++) ;
                tmp = b;
                for (lenB = 0; tmp != 0; tmp >>= 1, lenB++) ;
                k = lenA - lenB;
                b <<= k;
                exp += $"align divisor\n";
                exp += $"{Convert.ToString(a, 2)} mod divident\n";
                exp += $"{Convert.ToString(b, 2)} mod divisor\n\n";
                r = a + -b;
                q = r < 0 ? 0 : 1;
                exp += $"add divident and divisor in additional code\n";
                exp += $"остача = {Convert.ToString(r, 2)} \n";
                exp += $"ціла частина = {Convert.ToString(q, 2)} \n\n";
                for (int i = 0; i < k; i++)
                {
                    b >>= 1;
                    exp += $"{Convert.ToString(b, 2)} right shift divisor\n";
                    if (r < 0)
                    {
                        r += b;
                        exp += $"{Convert.ToString(r, 2)} add  remainder and divisor\n";
                    }
                    else
                    {
                        r += -b;
                        exp += $"{Convert.ToString(r, 2)} sub remainder and divisor\n";
                    }
                    q <<= 1;
                    if (r >= 0)
                        q++;
                    exp += $"{Convert.ToString(q, 2)} left shift quot {(r >= 0 ? "and add 1" : "")}\n\n";
                }
                if (r < 0)
                {
                    exp += "determine remain\n";
                    r += b;
                    exp += $"{Convert.ToString(r, 2)} r = r + b because r < 0 \n\n";
                }
                exp += "analyze sign bit of dividend and divisor and set sign to quot and rem\n";
                if (divident < 0)
                {
                    if (divisor > 0)
                        q = -q;
                    r = -r;
                }
                if (divident > 0 && divisor < 0)
                    q = -q;
                exp += $"quot = {Convert.ToString(q, 2)} remaind = {Convert.ToString(r, 2)}\n";
            }
            return (exp, q, r);
        }
        }
    }