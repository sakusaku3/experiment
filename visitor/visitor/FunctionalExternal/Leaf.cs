namespace visitor.FunctionalExternal
{
    class Leaf : Tree
    {
        public override T Accept<T>(TreeVisitor<T> visitor)
        {
            return visitor.VisitLeaf();
        }
    }
}
