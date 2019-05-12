namespace flowchart
{
    class DecisionShape : ShapeBase
    {
        public ConnectorLine SubLine { get; protected set; }

        public DecisionShape(string name) : base(name) { }

        public void SetSubLine(ConnectorLine line)
        {
            this.SubLine = line;
            line.StartShape = this;
        }

        public override T Accept<T>(IShapeVisitor<T> visitor)
        {
            return visitor.VisitDecision(this);
        }
    }
}
