using System;

namespace visitor.FunctionalExternal
{
    class ConcreteVisitor : TreeVisitor<Doc>
    {
        public Doc VisitLeaf()
        {
            return Doc.Text("Leaf");
        }

        public Doc VisitNode(Node node ,Tree lhs, Tree rhs)
        {
            var lhsDoc = node.LHS.Accept(this);
            var rhsDoc = node.RHS.Accept(this);
            var inner = lhsDoc.Concat(Doc.Line()).Concat(rhsDoc);
            return Doc.Bracket($"(Node {node.Value}", inner, ")");
        }
    }
}
