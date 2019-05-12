using System;

namespace visitor.classical
{
    class ConcreteVisitor : TreeVisitor
    {
        public void VisitLeaf()
        {
            Console.WriteLine("Leaf");
        }

        public void VisitNode(Node node)
        {
            Console.WriteLine($"Node {node.Value}");
        }
    }
}
