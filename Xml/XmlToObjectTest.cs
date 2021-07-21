using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFluent;
using Xml.model;
using Xunit;

namespace Xml
{
    public class XmlToObjectTest
    {
        [Fact]
        public void xml_to_object()
        {
            var company = SerializerService.DeserializeToObject<Company>("Company_1.xml");
            Check.That(company).IsNotNull();
            Check.That(company.Employees).HasSize(2);
            Check.That(company.Employees.First(employee => employee.Name == "Richard"))
                .HasFieldsWithSameValues(new {Age = "30", Name = "Richard"});
            Check.That(company.Employees.First(employee => employee.Name == "Mila"))
                .HasFieldsWithSameValues(new {Age = "32", Name = "Mila"});
        }

        [Fact]
        public void object_to_xml()
        {
            var company = new Company
            {
                Employees = new List<Employee> {new() {Age = "56", Name = "Alain"}, new() {Age = "12", Name = "Fred"}}
            };

            SerializerService.SerializeToXml(company, "Company_result.xml");
            var xml = File.ReadAllText("Company_result.xml");
            Check.That(xml).IsEqualTo(@"<?xml version=""1.0"" encoding=""utf-8""?>
<Company xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <Employee name=""Alain"" age=""56"" />
  <Employee name=""Fred"" age=""12"" />
</Company>");
        }
    }
}