namespace visitor
{
    class TextDoc : Doc
    {
        private readonly string str;
        private readonly Doc doc;

        public TextDoc(string str, Doc doc)
        {
            this.str = str;
            this.doc = doc;
        }

        public override string Layout()
        {
            return this.str + this.doc.Layout();
        }

        public override Doc Nest(int i)
        {
            return new TextDoc(str, doc.Nest(i));
        }

        public override Doc Concat(Doc other)
        {
            return new TextDoc(str, doc.Concat(other));
        }
    }
}
