using System;
using System.Globalization;

namespace Polynomial
{
    public class Format
    {
        public static float[] StringToFloatArr(string str)
        {
            var strArr = str.Split("\n");

            float[] poly = new float[strArr.Length];

            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] != "")
                {
                    Console.WriteLine(strArr[i]);
                    poly[i] = (float) Convert.ToDouble(strArr[i]);
                }
            }

            return poly;
        }

        public static string FloatArrToString(float[] poly)
        {
            string res = "";
            
            foreach (var f in poly)
            {
                res += f.ToString(CultureInfo.DefaultThreadCurrentCulture) + "\n";
            }

            return res;
        }

        public static string ToSuperScript(string str)
        {
            string res = "";
            foreach (var c in str)
            {
                char nc = ' ';
                switch (c)
                {
                    case '0':
                        nc = '⁰';
                        break;
                    case '1':
                        nc = '¹';
                        break;
                    case '2':
                        nc = '²';
                        break;
                    case '3':
                        nc = '³';
                        break;
                    case '4':
                        nc = '⁴';
                        break;
                    case '5':
                        nc = '⁵';
                        break;
                    case '6':
                        nc = '⁶';
                        break;
                    case '7':
                        nc = '⁷';
                        break;
                    case '8':
                        nc = '⁸';
                        break;
                    case '9':
                        nc = '⁹';
                        break;
                }

                res += nc;
            }

            return res;
        }
    }
}