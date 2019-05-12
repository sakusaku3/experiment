using System;

namespace visitor.ImprerativeExternal
{
    class ConcreteVisitor : TreeVisitor
    {
        private int depth = 0;

        public void VisitLeaf()
        {
            this.writeWithIndent("Leaf");
        }

        public void VisitNode(Node node)
        {
            this.writeWithIndent($"(Node {node.Value}");
            depth++;
            node.LHS.Accept(this);
            node.RHS.Accept(this);
            depth--;
            this.writeWithIndent(")");
        }

        private void writeWithIndent(string value)
        {
            Console.WriteLine($"{new string(' ', this.depth * 4)}{value}");
        }
    }
}
