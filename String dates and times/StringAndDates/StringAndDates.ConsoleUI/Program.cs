// See https://aka.ms/new-console-template for more information

using StringAndDates.Library;

List<string> stringList = new List<string>();

stringList.Add("Goergescu George");
stringList.Add("Matei Adrian");
stringList.Add("Manole Matei");

foreach (string str in stringList)
{
    Console.WriteLine(str.Length);

    if (str.Contains("George"))
    {
        Console.WriteLine($"Salutari {str} ! \n");
    }

    Console.WriteLine(str.Replace(" ", "-"));

}


ShiftHours worker1 = new ShiftHours();

worker1.StartWorking();
worker1.AddHoursWorkedFromHome(new TimeSpan(6, 0, 0));



worker1.StopWorking();

Console.WriteLine($"Hours worked by worker 1 : {worker1.TotalHoursWorked.TotalHours}");

Console.WriteLine($"Salary for worker 1 is { worker1.CalculateSalary(16)}");