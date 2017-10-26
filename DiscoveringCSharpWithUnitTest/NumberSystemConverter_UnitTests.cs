using System;
using NumberSystemConverter;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace NumberSystemConverterUnitTests
{
    [TestFixture]
    public class RomanNumeralConverterUpperAndLowerBoundsUnitTests
    {
        [Test]
        public void Number_Greater_Than_ThreeThousand_Throws_IndexOutOfRangeException_TestMethod()
        {
            Throws<IndexOutOfRangeException>(() => new RomanNumeralConverter().ConvertRomanNumeral(3001));
        }

        [Test]
        public void Number_Less_Than_One_Throws_IndexOutOfRangeException_TestMethod()
        {
            Throws<IndexOutOfRangeException>(() => new RomanNumeralConverter().ConvertRomanNumeral(-1));
        }

        [Test]
        public void Number_Zero_Throws_IndexOutOfRangeException_TestMethod()
        {
            Throws<IndexOutOfRangeException>(() => new RomanNumeralConverter().ConvertRomanNumeral(0));
        }
    }
}