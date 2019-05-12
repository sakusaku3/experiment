namespace flowchart
{
    interface IShapeVisitor<T>
    {
        T VisitBase(ShapeBase shape);
        T VisitProcess(ProcessShape shape);
        T VisitDecision(DecisionShape shape);
    }
}
