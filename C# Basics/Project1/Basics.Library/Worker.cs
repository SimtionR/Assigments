using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public abstract class Worker : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public abstract void DoWork();

        public abstract double CaculateSalary();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
