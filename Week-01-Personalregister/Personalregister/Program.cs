using Personalregister.Models;
using Personalregister.ConsoleHandler;

List<Personal> personalList = new()
{
	new Personal("Kalle", "Anka", 18000),
	new Personal("Kajsa", "Anka", 16800),
	new Personal("Mimmi", "Pigg", 26000),
};
var inputHandler = new InputHandler();
var menu = new MenuHandler(personalList, inputHandler);

menu.MainMenu();
