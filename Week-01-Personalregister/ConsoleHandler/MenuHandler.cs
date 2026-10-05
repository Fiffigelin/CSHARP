using System.Drawing;

namespace Personalregister.ConsoleHandler;

public class MenuItem
{
	public string Key { get; set; }
	public string Label { get; set; }
	public Action Action { get; set; }

	public MenuItem(string key, string label, Action action)
	{
		Key = key;
		Label = label;
		Action = action;
	}
}
public class MenuHandler()
{
	public
	static void Title(string? title)
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.DarkCyan;
		Console.WriteLine("   ༻❁𓌉◯𓇋❁༺");
		Console.ResetColor();
		Console.ForegroundColor = ConsoleColor.Blue;
		Console.WriteLine("Restaurant Eat");
		Console.ResetColor();

		if (title != null)
		{
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(title);

		}
		Console.WriteLine();
		Console.ResetColor();
	}

	public void ShowMenu(List<MenuItem> options)
	{
		Title(title: null);
		foreach (MenuItem option in options)
		{
			if (option.Key == "E")
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[{option.Key}] {option.Label}");
				Console.ResetColor();
			}
			else if (option.Key == "B")
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine($"[{option.Key}] {option.Label}");
				Console.ResetColor();
			}
			else if (option.Key == "S")
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"[{option.Key}] {option.Label}");
				Console.ResetColor();
			}
			else
			{
				Console.WriteLine($"[{option.Key}] {option.Label}");
			}
		}

		PickMenuItem(options);
	}

	public void PickMenuItem(List<MenuItem> options)
	{
		while (true)
		{
			Console.WriteLine();
			Console.Write("Välj: ");

			var pick = Console.ReadLine();
			var option = options.FirstOrDefault(o => o.Key == pick?.ToUpper());

			if (option != null)
			{
				option.Action();
				return;
			}

			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine("Something went wrong");
			Console.ResetColor();
		}
	}

	public void AddNewPersonal()
	{
		Title(title: "Add New Personal");
		Console.WriteLine("Nu ska vi skapa en ny personal :)");
	}

	public void ShowAllPersonal()
	{
		Title(title: "Show all personal");
		Console.WriteLine("Nu visar vi alla i personallistan");
	}
}