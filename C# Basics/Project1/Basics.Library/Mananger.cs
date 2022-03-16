using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public class Mananger : Worker, ISalary
    {
        public double Salary { get; private set; }
        public double CompanyProduction { get; private set; }
        public override double CaculateSalary()
        {
            return Salary + CompanyProduction * 0.1;
        }

        public void SetSalary(double salary)
        {
            if(salary <0 || salary > 10000)
            {
                Salary = 3000;
            }
            else
            {
                Salary = salary;
            }
        }

        public override void DoWork()
        {
            Console.WriteLine("Managerial Stuff");
        }

        public void SetBonuses(double bonuses)
        {
            //check if reuqirments for bonuses are done
            if(CompanyProduction >500000)
            {
                bonuses = bonuses;
            }
           
        }
    }
}
