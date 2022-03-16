using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public class ContractedWorker : Worker, ISalary
    {
        public int ContractDurationMonths { get; set; }
        public double SalaryPerMonth { get; private set; }
        public double Bonuses { get; private set; }

        public override void DoWork()
        {
            Console.WriteLine("Doing work");
        }

        public override double CaculateSalary()
        {
            return SalaryPerMonth + Bonuses;
        }

        public void SetSalary(double salary)
        {
            {
                if (salary > 0 || salary < 3500)
                {
                    SalaryPerMonth = salary;
                }
                else
                    SalaryPerMonth = 2500;
            }
        }

        public void SetBonuses(double bonuses)
            {
                if (ContractDurationMonths > 3)
                {
                    Bonuses = bonuses;
                }
                else
                {
                    Bonuses = bonuses * 0.5;
                }

        }
    }
}
