using System.Globalization;

namespace StringAndDates.Library
{
    public class ShiftHours
    {
        public DateTime StartingShift { get; set; }
        public DateTime EndingShift { get; set; }
        public TimeSpan TotalHoursWorked { get; set; }
        public double Salary { get; set; }


        public void StartWorking()
        {
            StartingShift = DateTime.Now;
        }


        public void StopWorking()
        {
            EndingShift = DateTime.Now;
            var workedHoursToday = TimeOnly.FromDateTime(EndingShift) - TimeOnly.FromDateTime(EndingShift);
            TotalHoursWorked += workedHoursToday;
        }

        public void AddHoursWorkedFromHome(TimeSpan workedHours)
        {
            TotalHoursWorked += workedHours;
        }

        public string  CalculateSalary(double hourlyRate)
        {
             Salary = hourlyRate * TotalHoursWorked.TotalHours;

            var salaryInLei = Salary.ToString("C", new CultureInfo("ro-RO"));

            return salaryInLei;
        }
    }
}