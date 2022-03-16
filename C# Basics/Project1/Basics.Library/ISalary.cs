using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public interface ISalary
    {
        public abstract void SetSalary(double salary);
        public abstract void SetBonuses(double bonuses);    
    }
}
