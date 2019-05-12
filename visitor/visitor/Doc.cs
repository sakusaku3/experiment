namespace visitor
{
    abstract class Doc
    {
        public static Doc Nil()
        {
            return NilDoc.Nil;
        }

        public static Doc Text(string str)
        {
            return new TextDoc(str, Nil());
        }

        private static readonly LineDoc line = new LineDoc(0, NilDoc.Nil);
        public static Doc Line()
        {
            return line;
        }

        public static Doc Bracket(string start, Doc inner, string end)
        {
            return Text(start).Concat(Line().Concat(inner).Nest(2).Concat(Line()).Concat(Text(end)));
        }

        public abstract string Layout();
        public abstract Doc Nest(int i);
        public abstract Doc Concat(Doc other);
    }
}
