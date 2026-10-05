using Personalregister.ConsoleHandler;
// using Personalregister.Models;


var Menu = new MenuHandler();
List<MenuItem> options = new()
{
	new MenuItem("A", "Add new personal", Menu.AddNewPersonal),
	new MenuItem("V", "Show all personal", Menu.ShowAllPersonal),
	new MenuItem("E", "Exit", () => Environment.Exit(0)),
};
// var personalList = new List<Personal>();

// Console.WriteLine("Skapa ny personalkonto");
// Console.Write("Fyll i förnamn: ");
// string firstName = Console.ReadLine();

// Console.Write("Fyll i efternamn: ");
// string lastName = Console.ReadLine();

// Console.Write("Fyll i månadslön: ");
// decimal salary = decimal.Parse(Console.ReadLine());

// personalList.Add(new Personal(firstName, lastName, salary));

// foreach (var personal in personalList)
// {
// 	Console.WriteLine(personal.GetFullname());
// 	Console.WriteLine(personal.SalaryByMonth);
// 	Console.ReadLine();
// }

Menu.ShowMenu(options);
