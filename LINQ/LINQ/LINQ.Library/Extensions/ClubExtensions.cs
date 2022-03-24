using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Library.Extensions
{
    public static class ClubExtensions
    {
        public static double GetLoanForBudget(this Club club, float loan)
        {
            return club.Budget += loan;
        }
    }
}
