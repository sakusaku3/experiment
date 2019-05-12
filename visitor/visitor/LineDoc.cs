using System;

namespace visitor
{
    class LineDoc : Doc
    {
        private readonly int depth;
        private readonly Doc doc;

        public LineDoc(int depth, Doc doc)
        {
            this.depth = depth;
            this.doc = doc;
        }

        public override string Layout()
        {
            return $"{Environment.NewLine}{new string(' ', depth * 4)}{this.doc.Layout()}";
        }

        public override Doc Nest(int i)
        {
            return new LineDoc(this.depth + i, this.doc.Nest(i));
        }

        public override Doc Concat(Doc other)
        {
            return new LineDoc(this.depth, this.doc.Concat(other));
        }
    }
}
