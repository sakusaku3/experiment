namespace flowchart
{
    class TypeExtructor : IShapeVisitor<string>
    {
        public string VisitBase(ShapeBase shape)
        {
            return nameof(ShapeBase);
        }

        public string VisitProcess(ProcessShape shape)
        {
            return nameof(ProcessShape);
        }

        public string VisitDecision(DecisionShape shape)
        {
            return nameof(DecisionShape);
        }
    }
}
