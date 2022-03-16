using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public class HourlyWorker : Worker
    {
        public double HoursWorked { get;  set; }
        public double SalaryHour { get;  set; }

        public override void DoWork()
        {
            Console.WriteLine("Doing work");
        }

      

        public override double CaculateSalary()
        {
            return HoursWorked * SalaryHour;
        }

       
    }
}
