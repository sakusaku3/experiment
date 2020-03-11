using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace datagrid_filter
{
    public class Cell : BindableBase
    {
        public string Value
        {
            get { return this._value; }
            set { this.SetProperty(ref this._value, value); }
        }
        private string _value;

        public Color Color
        {
            get { return this._color; }
            set { this.SetProperty(ref this._color, value); }
        }
        private Color _color;

        public Cell(string value, Color color)
        {
            this.Value = value;
            this.Color = color;
        }
    }
}
