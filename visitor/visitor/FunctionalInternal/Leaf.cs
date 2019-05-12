namespace visitor.FunctionalInternal
{
    class Leaf : Tree
    {
        public override T Accept<T>(TreeVisitor<T> visitor)
        {
            return visitor.VisitLeaf();
        }
    }
}
