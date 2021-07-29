using System;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
	[TestFixture]
	public class BooleanTests
	{
		[Test]
		public void bool_nullable()
		{
			bool? value = null;
			Check.ThatCode(() => (bool) value).Throws<InvalidOperationException>();
			
			Console.WriteLine(System.IO.Path.GetTempFileName());
			
		}
	}
}