namespace visitor.FunctionalInternal
{
    interface TreeVisitor<T>
    {
        T VisitLeaf();
        T VisitNode(Node node, T lhs, T rhs);
    }
}
