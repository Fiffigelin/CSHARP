using Models;

var personalList = new List<Personal>();

Console.WriteLine("Skapa ny personalkonto");
Console.Write("Fyll i förnamn: ");
string firstName = Console.ReadLine();

Console.Write("Fyll i efternamn: ");
string lastName = Console.ReadLine();

Console.Write("Fyll i månadslön: ");
decimal salary = decimal.Parse(Console.ReadLine());

personalList.Add(new Personal(firstName, lastName, salary));

foreach(var personal in personalList)
{
	Console.WriteLine(personal.GetFullname());
	Console.WriteLine(personal.SalaryByMonth);
	Console.ReadLine();
}

