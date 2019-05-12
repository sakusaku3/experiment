using System;

namespace visitor.FunctionalInternal
{
    class ConcreteVisitor : TreeVisitor<Doc>
    {
        public Doc VisitLeaf()
        {
            return Doc.Text("Leaf");
        }

        public Doc VisitNode(Node node, Doc lhs, Doc rhs)
        {
            var inner = lhs.Concat(Doc.Line()).Concat(rhs);
            return Doc.Bracket($"(Node {node.Value}", inner, ")");
        }
    }
}
