using Personalregister.Models;

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
public class MenuHandler(List<Personal> PersonalList)
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

	public void MainMenu()
	{
		Title(title: null);
		List<MenuItem> options = new()
		{
			new MenuItem("A", "Add new personal", AddNewPersonal),
			new MenuItem("V", "Show all personal", ShowAllPersonal),
			new MenuItem("E", "Exit", () => Environment.Exit(0)),
		};

		ShowMenu(options);
	}

	public void SavePersonalMenu(Personal personal)
	{
		List<MenuItem> options = new()
		{
			new MenuItem("S", "Save", () => SaveNewPersonal(personal)),
			new MenuItem("B", "Back", MainMenu)
		};

		Console.WriteLine();
		ShowMenu(options);
	}

	public void SaveNewPersonal(Personal personal)
	{
		PersonalList.Add(personal);
		Console.WriteLine();

		if (PersonalList.Contains(personal))
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Personal added successfully!");
			Console.ResetColor();
			Console.WriteLine("Press any key to return to mainpage");
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Something happened! Please try again.");
			Console.ResetColor();
			Console.WriteLine("Press any key to return to mainpage");
		}
		Console.ReadLine();
		MainMenu();
	}

	public void AddNewPersonal()
	{

		Title(title: "Add New Personal");
		Console.Write("Firstname: ");
		string firstName = Console.ReadLine();

		Console.Write("Lastname: ");
		string lastName = Console.ReadLine();

		Console.Write("Monthly salary: ");
		decimal salary = decimal.Parse(Console.ReadLine());

		SavePersonalMenu(new Personal(firstName, lastName, salary));
	}

	public void ShowAllPersonal()
	{
		Title(title: "Show all personal");
		PersonalTable();

		List<MenuItem> options = new()
		{
			new MenuItem("B", "Back", MainMenu),
		};

		Console.WriteLine();
		ShowMenu(options);
	}

	public void PersonalTable()
	{
		// detta bad jag ai göra för mig
		Console.WriteLine($"{"Namn",-20} | {"Lön",10}");
		Console.WriteLine(new string('-', 33));

		foreach (Personal personal in PersonalList)
		{
			Console.WriteLine($"{personal.GetFullname(),-20} | {personal.SalaryByMonth,10}");
		}
	}
}