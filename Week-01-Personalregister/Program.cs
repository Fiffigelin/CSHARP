using Personalregister.ConsoleHandler;
using Personalregister.Models;


List<Personal> personalList = new()
{
	new Personal("Kalle", "Anka", 18000),
	new Personal("Kajsa", "Anka", 16800),
	new Personal("Mimmi", "Pigg", 26000),
};
var Menu = new MenuHandler(personalList);
List<MenuItem> options = new()
{
	new MenuItem("A", "Add new personal", Menu.AddNewPersonal),
	new MenuItem("V", "Show all personal", Menu.ShowAllPersonal),
	new MenuItem("E", "Exit", () => Environment.Exit(0)),
};

Menu.MainMenu();
