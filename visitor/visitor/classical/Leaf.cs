namespace visitor.classical
{
    class Leaf : Tree
    {
        public override void Accept(TreeVisitor visitor)
        {
            visitor.VisitLeaf();
        }
    }
}
