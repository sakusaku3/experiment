namespace visitor.ImprerativeExternal
{
    abstract class Tree
    {
        public abstract void Accept(TreeVisitor visitor);
    }
}
