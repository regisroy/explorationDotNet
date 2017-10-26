using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace CSharp6Test
{
    [TestClass]
    public class FormattageToStringTest
    {
        [TestMethod]
        public void DateToString()
        {
            var dateTime = new DateTime(2017, 02, 07, 15, 23, 12);
            Check.That($"{dateTime:yyyy-MM-dd_H'h'mm'm'ss's'}").IsEqualTo("2017-02-07_15h23m12s");
            Check.That($"{dateTime:dd MMMM yyyy}").IsEqualTo("07 February 2017");  //Dépend de la langue du poste de travail, si Français: "07 février 2017"
            Check.That($"{dateTime:d MMMM yyyy}").IsEqualTo("7 February 2017");    //Dépend de la langue du poste de travail, si Français: "7 février 2017"
            const string format = "d MMMM yyyy";
            Check.That(dateTime.ToString(format)).IsEqualTo("7 February 2017");    //Dépend de la langue du poste de travail, si Français: "7 février 2017"
        }

        [TestMethod]
        public void TrimReplace()
        {
            Check.That("".Trim().Replace(" ", "")).IsEqualTo("");
            Check.That("    ".Trim().Replace(" ", "")).IsEqualTo("");
            Check.That("75010".Trim().Replace(" ", "")).IsEqualTo("75010");
            Check.That("75 010 ".Trim().Replace(" ", "")).IsEqualTo("75010");
            Check.That(" 75 010 ".Trim().Replace(" ", "")).IsEqualTo("75010");
        }
    }
}