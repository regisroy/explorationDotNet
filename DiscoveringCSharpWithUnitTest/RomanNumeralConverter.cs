using System;

namespace NumberSystemConverter_UnitTests
{
    internal class RomanNumeralConverter
    {
        public RomanNumeralConverter()
        {
        }

        public void ConvertRomanNumeral(int p)
        {
            if (p < 1 || p > 3000)
            {
                throw new IndexOutOfRangeException("The number supplied is out of the expected range (1 - 3000).");
            }
        }
    }
}