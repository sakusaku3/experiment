namespace visitor.classical
{
    interface TreeVisitor
    {
        void VisitLeaf();
        void VisitNode(Node node);
    }
}
