// See https://aka.ms/new-console-template for more information
using ExceptionHandling_Debugging.Library;

#if DEBUG
Console.WriteLine("Aloha from debug stage");
#endif

Console.WriteLine("Pass the id of the conteder you want to know info about: ");

var contederId = 0;

try
{
    contederId = int.Parse(Console.ReadLine());
}
catch (Exception ex )
{
    //log exception
    Console.WriteLine("Bad input, write an id "); 
}



ExceptionsExemple exemple = new ExceptionsExemple();

if(contederId !=0)
{
    try
    {

        exemple.GetInfoAboutContender(contederId);

        if (exemple.isQualified)
        {
            Console.WriteLine($"Score of contenderID: {contederId} is {exemple.score}. Congrats, the conteder goes into the next stage");
        }
        else
        {
            Console.WriteLine($"Score of contenderID: {contederId} is {exemple.score}. Try harder");
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
    }
}