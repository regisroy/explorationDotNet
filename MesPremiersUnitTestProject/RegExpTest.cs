using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MesPremiersUnitTestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NUnit.Framework;

namespace CSharp6Test
{
    [TestFixture]
    public class RegExpTest
    {
        [Test]
        public void Replace()
        {
            var input = @"C:\Projects\Generation/AAA\GeneratedCode\DataLayer/Factories\PersonneFactory.cs";
            var projectDir = @"GeneratedCode\DataLayer";
            string pattern = ".*" + projectDir.Replace(@"\", @"[\\|/]") + "";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var actual = regex.Replace(input, projectDir);
            Check.That(actual).IsEqualTo(@"GeneratedCode\DataLayer/Factories\PersonneFactory.cs");
        }
    }
}