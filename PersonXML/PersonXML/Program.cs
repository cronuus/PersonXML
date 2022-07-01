using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xml = XDocument.Load("XMLFile1.xml");
            var persons = xml.Descendants("person");
            var teachers = persons.Select(person => person.Elements("teacher"));
            var qualificationsContainer = teachers.SelectMany(teacher => teacher.Elements("qualifications"));
            var qualifications = qualificationsContainer.SelectMany(qualificationContainer => qualificationContainer.Elements("qualification"));
            var qualificationIds = qualifications.Select(qualification => qualification.Element("id").Value);
        }
    }
}
