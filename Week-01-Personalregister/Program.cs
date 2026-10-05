using Personalregister.ConsoleHandler;
using Personalregister.Models;


var personalList = new List<Personal>();
var Menu = new MenuHandler(personalList);
List<MenuItem> options = new()
{
	new MenuItem("A", "Add new personal", Menu.AddNewPersonal),
	new MenuItem("V", "Show all personal", Menu.ShowAllPersonal),
	new MenuItem("E", "Exit", () => Environment.Exit(0)),
};

// foreach (var personal in personalList)
// {
// 	Console.WriteLine(personal.GetFullname());
// 	Console.WriteLine(personal.SalaryByMonth);
// 	Console.ReadLine();
// }

Menu.MainMenu();
