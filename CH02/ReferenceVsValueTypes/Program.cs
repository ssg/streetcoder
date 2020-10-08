using System;
using System.Text;

namespace ReferenceVsValueTypes
{
    internal class Program
    {
        public static void Main()
        {
            int result = 5;
            var date = new DateTime(1984, 10, 9);
            var builder = new StringBuilder();
            string formula = "2 + 2 = ";
            builder.Append(formula);
            builder.Append(result);
            builder.Append(date.ToString());
            Console.WriteLine(builder.ToString());
        }
    }
}