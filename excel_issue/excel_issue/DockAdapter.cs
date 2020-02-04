using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using docks;

namespace excel_issue
{
    public partial class DockAdapter : UserControl
    {
        internal Dock Adaptee { get; private set; }
        
        public DockAdapter()
        {
            this.InitializeComponent();
            this.Adaptee = new Dock();
            var ehost = new ElementHost
            {
                Dock = DockStyle.Fill,
                Child = this.Adaptee,
            };
            this.Controls.Add(ehost);
        }
    }
}
