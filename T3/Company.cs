using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLOOP2_L3.T3
{
    internal class Company
    {
        public string Name { get; init; }
        public List<Employed> Employee { get; init; }

        public Company(string name, List<Employed> employee) 
        {
            this.Name = name;
            Employee = employee;
        }

        public Company() : this("NoName", []) { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Employed employed in Employee)
            {
                sb.Append(employed.ToString());
            }
            return sb.ToString();
        }
    }
}
