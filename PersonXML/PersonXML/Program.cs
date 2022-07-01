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
            var people = xml.Descendants("person");
            var qualificationIds = people.SelectMany(p => p.Elements("teacher"))
                                        .SelectMany(t => t.Elements("qualifications"))
                                        .SelectMany(qs => qs.Elements("qualification"))
                                        .Select(q => q.Element("id").Value);
            var uniqueQualificationIds = qualificationIds.Distinct();
            foreach (var item in uniqueQualificationIds)
            {
                Console.WriteLine(item);
            }
        }
    }
}
