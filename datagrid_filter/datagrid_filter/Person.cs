using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datagrid_filter
{
    public class Person : BindableBase
    {
        private int salary;

        public int Salary
        {
            get { return this.salary; }
            set { this.SetProperty(ref this.salary, value); }
        }

        private string name;

        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }
    }
}
