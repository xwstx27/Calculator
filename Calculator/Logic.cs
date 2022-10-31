using System.Data;
using System.Linq;

namespace Calculator
{
    public class Logic
    {
        public string GetResult(string expression)
        {
            if (expression == "EXCEEDED" || expression == "NOT / 0" || expression.Length == 0)
            {
                return null;
            }

            string result = expression.Replace('x', '*');

            try
            {
                result = new DataTable()
                            .Compute(result, "")
                            .ToString()
                            .Replace(',', '.');
            }
            catch
            {
                result = "EXCEEDED";
            }

            if ((result.Length >= 8 && result.Contains('.')) || result == "не число")
            {
                result = "EXCEEDED";
            }

            if (result == "∞")
            {
                result = "NOT / 0";
            }

            return result;
        }

        public string NegateNumber(string number)
        {
            if (number == "0")
            {
                return number;
            }

            return (double.Parse(number) * -1).ToString();
        }
    }
}
