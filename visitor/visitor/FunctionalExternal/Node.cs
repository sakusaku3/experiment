namespace visitor.FunctionalExternal
{
    class Node : Tree
    {
        public int Value { get; private set; }
        public Tree LHS { get; private set; }
        public Tree RHS { get; private set; }

        public Node(int value, Tree lhs, Tree rhs)
        {
            this.Value = value;
            this.LHS = lhs;
            this.RHS = rhs;
        }

        public override T Accept<T>(TreeVisitor<T> visitor)
        {
            return visitor.VisitNode(this, this.LHS, this.RHS);
        }
    }
}
