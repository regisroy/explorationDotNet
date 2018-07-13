using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
	[TestFixture]
	public class BooleanTests
	{
		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void bool_nullable()
		{
			bool? value = null;
			Check.ThatCode(() => (bool) value).Throws<InvalidOperationException>();
		}
	}
}