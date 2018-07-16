using NumberSystemConverter;
using NUnit.Framework;

namespace NumberSystemConverterUnitTests
{
    [TestFixture]
    public class RomanNumeralConverterExpectedValuesUnitTests
    {
        [Test]
        public void Number_Equal_One_Expected_Result_I_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(1);

            Assert.AreEqual(result, "I");
        }

        [Test]
        public void Number_Equal_ThreeThousand_Expected_Result_MMM_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(3000);

            Assert.AreEqual(result, "MMM");
        }

        [Test]
        public void Number_Equal_55_Expected_Result_LV_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(55);

            Assert.AreEqual(result, "LV");
        }

        [Test]
        public void Number_Equal_100_Expected_Result_C_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(100);

            Assert.AreEqual(result, "C");
        }

        [Test]
        public void Number_Equal_500_Expected_Result_D_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(500);

            Assert.AreEqual(result, "D");
        }

        [Test]
        public void Number_Equal_599_Expected_Result_DLXXXXVIIII_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(599);

            Assert.AreEqual(result, "DLXXXXVIIII");
        }

        [Test]
        public void Number_Equal_2013_Expected_Result_MMXIII_TestMethod()
        {
            var converter = new RomanNumeralConverter();
            var result = converter.ConvertRomanNumeral(2013);

            Assert.AreEqual(result, "MMXIII");
        }
    }
}