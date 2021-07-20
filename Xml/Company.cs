using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Xml
{
    [XmlRoot(ElementName = "Company")]  
    public class Company  
    {  
        public Company()  
        {  
            Employees = new List<Employee>();  
        }  
  
        [XmlElement(ElementName = "Employee")]  
        public List<Employee> Employees { get; set; }  
  
        public Employee this[string name]  
        {  
            get { return Employees.FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)); }  
        }  
    }  
  
    public class Employee  
    {  
        [XmlAttribute("name")]  
        public string Name { get; set; }  
  
        [XmlAttribute("age")]  
        public string Age { get; set; }  
    }  
}