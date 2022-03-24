using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Library.Extensions
{
    public static class PlayerExtensions
    {
        public static void HasScored(this Player player)
        {
            Console.WriteLine($"{player.FirstName} has Scored");
        }

        public static double RaiseSalary(this Player player, double salaryIncrease)
        {
            return player.Salary += salaryIncrease;
        }
    }
}
