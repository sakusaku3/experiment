namespace visitor
{
    class NilDoc : Doc
    {
        public static new NilDoc Nil = new NilDoc();
        private NilDoc() { }

        public override string Layout()
        {
            return string.Empty;
        }

        public override Doc Nest(int i)
        {
            return this;
        }

        public override Doc Concat(Doc other)
        {
            return other;
        }
    }
}
