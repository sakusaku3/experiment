namespace visitor.FunctionalExternal
{
    interface TreeVisitor<T>
    {
        T VisitLeaf();
        T VisitNode(Node node, Tree lhs, Tree rhs);
    }
}
