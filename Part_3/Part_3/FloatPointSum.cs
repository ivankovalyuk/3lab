using System;

namespace Part_3
{
    class FloatPointSum
    {
        public static (string def, string floatResult, float result) Add(float a, float b)
        {
            uint a1 = BitConverter.ToUInt32(BitConverter.GetBytes(a), 0);
            uint b1 = BitConverter.ToUInt32(BitConverter.GetBytes(b), 0);
            uint sa = a1 >> 31;
            uint sb = b1 >> 31;
            uint ea = (a1 >> 23) & 0xFF;
            uint eb = (b1 >> 23) & 0xFF;
            uint ma = (a1 & 0x7FFFFF) + 8388608;
            uint mb = (b1 & 0x7FFFFF) + 8388608;
            string descr = $"{a} + {b}\n\n";
            descr += $"a = {Convert.ToString(a1, 2)}\n";
            descr += $"b = {Convert.ToString(b1, 2)}\n\n";
            descr += $"sa = {sa} ea = {Convert.ToString(ea, 2)} ma = {Convert.ToString(ma, 2)}\n";
            descr += $"sb = {sb} eb = {Convert.ToString(eb, 2)} mb = {Convert.ToString(mb, 2)}\n";
            if (((ea << 23) + ma) < ((eb << 23) + mb))
            {
                uint temp = a1;
                a1 = b1;
                b1 = temp;
                temp = ea;
                ea = eb;
                eb = temp;
                temp = sa;
                sa = sb;
                sb = temp;
                temp = ma;
                ma = mb;
                mb = temp;
                descr += "\nЗамінюємо значення, тому що Abs(a1) < Abs(a2)\n";
                descr += $"sa = {sa} ea = {Convert.ToString(ea, 2)} ma = {Convert.ToString(ma, 2)}\n";
                descr += $"sb = {sb} eb = {Convert.ToString(eb, 2)} mb = {Convert.ToString(mb, 2)}\n";
            }
            uint er = ea;

            mb >>= (int)(ea - eb);
            descr += $"\nЗдвигаємо вправо mb на різн. експонент {ea - eb}\n";
            descr += $"sb = {sb} eb = {Convert.ToString(eb, 2)} mb = {Convert.ToString(mb, 2)}\n";

            uint m;

            if (sa == sb)
                m = ma + mb;
            else
                m = ma - mb;

            descr += $"\nОбчислюємо {(sa == sb ? "суму" : "ріницю")} мантис\n";
            descr += $"s3 = {sa} er = {Convert.ToString(er, 2)} mr = {Convert.ToString(m, 2)}\n";
            if (m >> 23 != 1)
            {
                int len;
                uint temp = m;
                for (len = 0; temp != 0; temp >>= 1, len++) ;

                er += (uint)(len - 24);
                if (len > 24)
                    m >>= (len - 24);
                else
                    m <<= (24 - len);

                descr += "\nНормалізуємо результат\n";
                descr += $"s3 = {sa} e3 = {Convert.ToString(er, 2)} m3 = {Convert.ToString(m, 2)}\n";
            }

            uint result = (((sa << 8) + er) << 23) + (m & 0x7FFFFF);
            float floatResult = BitConverter.ToSingle(BitConverter.GetBytes(result), 0);

            return (descr, Convert.ToString(result, 2), floatResult);
        }
    }
}
