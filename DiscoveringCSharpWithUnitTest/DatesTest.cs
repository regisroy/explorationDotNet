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
			Check.That(new DateTime(2017, 01, 01, 12, 03, 56).Hour).IsEqualTo(new DateTime(2014, 03, 15, 12, 08, 44).Hour);
			Check.That(new DateTime(2017, 01, 01, 05, 03, 56).Minute).IsEqualTo(new DateTime(2014, 03, 15, 12, 03, 44).Minute);
			Check.That(new DateTime(2017, 01, 01, 05, 03, 56).Second).IsEqualTo(new DateTime(2014, 03, 15, 12, 12, 56).Second);
			Check.That(new DateTime(2017, 01, 01, 05, 03, 56).Day).IsNotEqualTo(new DateTime(2014, 03, 15, 12, 12, 56).Day);
		}

		[Test]
		public void DateTodayVsNow()
		{
			Check.That(DateTime.UtcNow.ToLocalTime().Hour).IsEqualTo(DateTime.Now.Hour);
			Check.That(DateTime.UtcNow.ToLocalTime().Minute).IsEqualTo(DateTime.Now.Minute);
			Check.That(DateTime.UtcNow.ToLocalTime().Second).IsEqualTo(DateTime.Now.Second);
			Check.That(DateTime.UtcNow.ToLocalTime().Year).IsEqualTo(DateTime.Now.Year);
			Check.That(DateTime.UtcNow.ToLocalTime().Month).IsEqualTo(DateTime.Now.Month);
			Check.That(DateTime.UtcNow.ToLocalTime().Day).IsEqualTo(DateTime.Now.Day);

			Check.That(DateTime.Today.Hour).IsEqualTo(0);
			Check.That(DateTime.Today.Minute).IsEqualTo(0);
			Check.That(DateTime.Today.Second).IsEqualTo(0);
			Check.That(DateTime.Today.Millisecond).IsEqualTo(0);
			Check.That(DateTime.Today.Year).IsEqualTo(DateTime.Now.Year);
			Check.That(DateTime.Today.Month).IsEqualTo(DateTime.Now.Month);
			Check.That(DateTime.Today.Day).IsEqualTo(DateTime.Now.Day);
		}
	}
}