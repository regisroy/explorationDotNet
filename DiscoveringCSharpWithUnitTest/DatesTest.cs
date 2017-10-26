using System;
using NFluent;
using NUnit.Framework;

namespace CSharp6
{
    [TestFixture]
    public class DatesTest
    {
        [Test]
        public void CompareDatesWithoutHour()
        {
            Check.That(new DateTime(2017, 03, 15, 12, 03, 56) == new DateTime(2017, 03, 15, 12, 03, 56)).IsTrue();
            Check.That(new DateTime(2017, 03, 15, 12, 03, 56).Equals(new DateTime(2017, 03, 15, 12, 03, 56))).IsTrue();
            Check.That(new DateTime(2017, 03, 15, 11, 11, 11).Equals(new DateTime(2017, 03, 15, 12, 03, 56))).IsFalse();
            Check.That(new DateTime(2017, 03, 15, 11, 11, 11).Date == new DateTime(2017, 03, 15, 12, 03, 56).Date).IsTrue();
            Check.That(new DateTime(2017, 03, 15, 11, 11, 11).Date == new DateTime(2016, 03, 15, 12, 03, 56).Date).IsFalse();
            Check.That(new DateTime(2017, 03, 15, 11, 11, 11).Date != new DateTime(2016, 03, 15, 12, 03, 56).Date).IsTrue();
        }

        [Test]
        public void CompareHourMinuteSecondes()
        {
            Check.That(new DateTime(2017, 01, 01, 12, 03, 56).Hour == new DateTime(2014, 03, 15, 12, 08, 44).Hour).IsTrue();
            Check.That(new DateTime(2017, 01, 01, 05, 03, 56).Minute == new DateTime(2014, 03, 15, 12, 03, 44).Minute).IsTrue();
            Check.That(new DateTime(2017, 01, 01, 05, 03, 56).Second == new DateTime(2014, 03, 15, 12, 12, 56).Second).IsTrue();
            Check.That(new DateTime(2017, 01, 01, 05, 03, 56). Day != new DateTime(2014, 03, 15, 12, 12, 56).Day).IsTrue();
        }
    }
}