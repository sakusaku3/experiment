using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
	[DataContract(Namespace = "")]
    public class Person
    {
        [DataMember()]
        public string Name { get; set; }

        private Person() { }
        public Person(string p_name)
        {
            this.Name = p_name;
        }
    }
}
