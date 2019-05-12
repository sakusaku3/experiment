using System.Collections.Generic;

namespace flowchart
{
    class Layouter : IShapeVisitor<bool>
    {
        private int currentColumn = 0;
        private int currentRow = 0;

        private Dictionary<ShapeBase, bool> visited
            = new Dictionary<ShapeBase, bool>();

        public bool VisitBase(ShapeBase shape)
        {
            shape.Column = this.currentColumn;
            shape.Row = this.currentRow;
            this.visited[shape] = true;

            if (shape?.MainLine?.EndShape == null) return true;
            if (this.visited.ContainsKey(shape.MainLine.EndShape))
            {
                shape.MainLine.EndShape.Row = shape.Row + 1;
            }
            else
            {
                this.currentRow++;
                shape.MainLine.EndShape.Accept(this);
            }

            return true;
        }

        public bool VisitProcess(ProcessShape shape)
        {
            return this.VisitBase(shape);
        }

        public bool VisitDecision(DecisionShape shape)
        {
            this.VisitBase(shape);

            if (shape?.SubLine?.EndShape == null) return true;
            if (!this.visited.ContainsKey(shape.SubLine.EndShape))
            {
                this.currentRow = shape.Row + 1;
                this.currentColumn++;
                shape.SubLine.EndShape.Accept(this);
            }

            return true;
        }
    }
}
