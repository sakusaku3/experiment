using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visitor.classical
{
    abstract class Tree
    {
        public abstract void Accept(TreeVisitor visitor);
    }
}
