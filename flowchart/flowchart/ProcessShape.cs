using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flowchart
{
    class ProcessShape : ShapeBase
    {
        public ProcessShape(string name) : base(name) { }

        public override T Accept<T>(IShapeVisitor<T> visitor)
        {
            return visitor.VisitProcess(this);
        }
    }
}
