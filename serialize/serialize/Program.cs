using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
    class Program
    {
        static readonly string PATH = "test3.xml";
        static void Main(string[] args)
        {
            //var l_teamA = new Team(new List<Person>
            //{
            //    new Person("AAA"),
            //    new Person("BBB"),
            //    new Person("CCC"),
            //});

            //XmlConverter.Save(l_teamA, PATH);

            var l_teamB = XmlConverter.Load<Team>(PATH);

            Console.ReadKey();
        }
    }
}
