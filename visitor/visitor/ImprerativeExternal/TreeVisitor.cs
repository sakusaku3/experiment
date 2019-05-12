namespace visitor.ImprerativeExternal
{
    interface TreeVisitor
    {
        void VisitLeaf();
        void VisitNode(Node node);
    }
}
