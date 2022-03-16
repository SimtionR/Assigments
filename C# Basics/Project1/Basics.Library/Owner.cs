using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Library
{
    public class Owner : Worker
    {
        public double CompanyCosts { get; private set; }
        public double CompanyProduction { get; private set; }
        public override void DoWork()
        {
            Console.WriteLine("Deciding business trajectory");
        }

        public void GeneratePerformanceReview(Worker worker)
        {
            
            Console.WriteLine("Reviewing a worker's performance.");
        }

        public void GeneratePerformanceReview(List<Worker> workers)
        {
            Console.WriteLine("Reviewing departament's performance");
        }

        public void FireSomeone()
        {
            // Simulate firing someone
            Console.WriteLine("You're Fired!");
        }

        public override double CaculateSalary()
        {
            return CompanyProduction - CompanyCosts;
        }

        
    }
}
