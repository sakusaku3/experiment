using System;

namespace visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- classical ---");
            var node = new classical.Node(1, 
                new classical.Leaf(), 
                new classical.Node(2, 
                    new classical.Leaf(), 
                    new classical.Leaf()));

            node.Accept(new classical.ConcreteVisitor());
            Console.WriteLine("--- end classical ---");

            Console.WriteLine("--- ImprerativeExternal ---");
            var ieNode = new ImprerativeExternal.Node(1, 
                new ImprerativeExternal.Leaf(), 
                new ImprerativeExternal.Node(2, 
                    new ImprerativeExternal.Leaf(), 
                    new ImprerativeExternal.Leaf()));

            ieNode.Accept(new ImprerativeExternal.ConcreteVisitor());
            Console.WriteLine("--- end ImprerativeExternal ---");

            Console.WriteLine("--- FunctionalInternal ---");
            var fiNode = new FunctionalInternal.Node(1, 
                new FunctionalInternal.Leaf(), 
                new FunctionalInternal.Node(2, 
                    new FunctionalInternal.Leaf(), 
                    new FunctionalInternal.Leaf()));

            var fiDoc = fiNode.Accept(new FunctionalInternal.ConcreteVisitor());
            Console.WriteLine(fiDoc.Layout());
            Console.WriteLine("--- end FunctionalInternal ---");

            Console.WriteLine("--- FunctionalExternal ---");
            var feNode = new FunctionalExternal.Node(1, 
                new FunctionalExternal.Leaf(), 
                new FunctionalExternal.Node(2, 
                    new FunctionalExternal.Leaf(), 
                    new FunctionalExternal.Leaf()));

            var feDoc = feNode.Accept(new FunctionalExternal.ConcreteVisitor());
            Console.WriteLine(fiDoc.Layout());
            Console.WriteLine("--- end FunctionalExternal ---");

            Console.WriteLine("please enter key to exit ...");
            Console.ReadKey();
        }
    }
}
