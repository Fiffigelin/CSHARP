using Personalregister.ConsoleHandler;
// using Personalregister.Models;


var Menu = new MenuHandler();
var PersonalHandler = new PersonalHandler();
List<MenuItem> options = new()
{
	new MenuItem(MenuItem.ItemKey.A, "Add new personal", PersonalHandler.AddNewPersonal),
	new MenuItem(MenuItem.ItemKey.V, "Show all personal", PersonalHandler.ShowAllPersonal),
	new MenuItem(MenuItem.ItemKey.E, "Exit", () => Environment.Exit(0)),
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
