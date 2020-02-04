using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace excel_issue
{
    public partial class AdditionalRibbon
    {
        private void AdditionalRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void Button1_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.ChangeWindow(DockTypes.Dock); 
        }
    }
}
