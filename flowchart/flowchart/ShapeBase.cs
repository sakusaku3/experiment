using System.Collections.Generic;

namespace flowchart
{
    abstract class ShapeBase
    {
        public string Name { get; protected set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public IEnumerable<ConnectorLine> PreviousLines => this._previousLines;
        private List<ConnectorLine> _previousLines = new List<ConnectorLine>();

        public ConnectorLine MainLine { get; protected set; }

        public ShapeBase(string name)
        {
            this.Name = name;
        }

        public void SetMainLine(ConnectorLine line)
        {
            this.MainLine = line;
            line.StartShape = this;
        }

        public void AddPreviousLine(ConnectorLine line)
        {
            this._previousLines.Add(line);
            line.EndShape = this;
        }

        public virtual T Accept<T>(IShapeVisitor<T> visitor)
        {
            return visitor.VisitBase(this);
        }
    }
}
