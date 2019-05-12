namespace visitor.FunctionalInternal
{
    abstract class Tree
    {
        public abstract T Accept<T>(TreeVisitor<T> visitor);
    }
}
