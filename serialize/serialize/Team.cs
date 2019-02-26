using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace serialize
{
    [DataContract(Namespace = "")]
    public class Team
    {
        [DataMember()]
        public NewObser<Person> Members { get; set; }
            = new NewObser<Person>();

        public List<Person> Members { get; set; }
            = new NewObser<Person>();

        public Team() { }
        public Team(IEnumerable<Person> p_menbers)
        {
            foreach (var l_m in p_menbers)
            {
                this.Members.Add(l_m);
            }
        }

        //
        // OnSerializing属性を付加したメソッドが呼ばれるのは
        // BinaryFormatter等のRuntime Serializerを利用した場合のみ。
        // (XmlSerializerを利用している場合、このメソッドは呼ばれない。)
        //
        [OnSerializing]
        void OnSerializing(StreamingContext context)
        {
            Console.WriteLine("OnSerializing={0},{1}", context.State, context.Context);
        }

        //
        // OnSerialized属性を付加したメソッドが呼ばれるのは
        // BinaryFormatter等のRuntime Serializerを利用した場合のみ。
        // (XmlSerializerを利用している場合、このメソッドは呼ばれない。)
        //
        [OnSerialized]
        void OnSerialized(StreamingContext context)
        {
            Console.WriteLine("OnSerialized={0},{1}", context.State, context.Context);
        }

        //
        // OnDeserializing属性を付加したメソッドが呼ばれるのは
        // BinaryFormatter等のRuntime Serializerを利用した場合のみ。
        // (XmlSerializerを利用している場合、このメソッドは呼ばれない。)
        //
        [OnDeserializing]
        void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("OnDeserializing={0},{1}", context.State, context.Context);
        }

        //
        // OnDeserialized属性を付加したメソッドが呼ばれるのは
        // BinaryFormatter等のRuntime Serializerを利用した場合のみ。
        // (XmlSerializerを利用している場合、このメソッドは呼ばれない。)
        //
        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("OnDeserialized={0},{1}", context.State, context.Context);
        }
    }
}
