namespace visitor.ImprerativeExternal
{
    class Leaf : Tree
    {
        public override void Accept(TreeVisitor visitor)
        {
            visitor.VisitLeaf();
        }
    }
}
