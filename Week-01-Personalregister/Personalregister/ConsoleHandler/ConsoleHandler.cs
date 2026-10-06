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

public enum EditChoice
{
	FirstName,
	LastName,
	Salary,
	Delete
}
public class ConsoleHandler(List<Personal> PersonalList, InputHandler inputHandler)
{
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
			if (option.Key == "E" || option.Key == "D")
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
			Console.Write("Choose: ");

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
			new MenuItem("1", "Add new personal", AddNewPersonal),
			new MenuItem("2", "Show all personal", ShowAllPersonal),
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

		string firstName = inputHandler.ValidateStringInput("Firstname: ");
		string lastName = inputHandler.ValidateStringInput("Lastname: ");
		decimal salary = inputHandler.ValidateDecimalInput("Monthly salary: ");

		SavePersonalMenu(new Personal(firstName, lastName, salary));
	}

	public void ShowAllPersonal()
	{
		Title(title: "Show all personal");
		PersonalTable(PersonalList);

		List<MenuItem> options = new()
		{
			new MenuItem("1", "Edit", ChoosePersonalToEdit),
			new MenuItem("B", "Back", MainMenu),
		};

		Console.WriteLine();
		ShowMenu(options);
	}

	public void ChoosePersonalToEdit()
	{
		Title(title: "Show all personal");
		PersonalTable(PersonalList);

		List<MenuItem> options = new();
		for (int i = 0; i < PersonalList.Count; i++)
		{
			var personal = PersonalList[i];
			string key = (i + 1).ToString();
			options.Add(new MenuItem(key, personal.GetFullname(), () => ShowSinglePersonal(personal, key)));
		}

		options.Add(new MenuItem("B", "Back", MainMenu));

		Console.WriteLine();
		ShowMenu(options);
	}

	public void ShowSinglePersonal(Personal personal, string key)
	{
		Title(title: $"Show {personal.GetFullname()}");
		int keyNumber = int.Parse(key);

		SinglePersonalTable(personal, keyNumber);
		Console.WriteLine();

		List<MenuItem> options = new()
		{
			new MenuItem("1", "Edit first name", () => EditPick(personal, key, EditChoice.FirstName)),
			new MenuItem("2", "Edit last name", () => EditPick(personal, key, EditChoice.LastName)),
			new MenuItem("3", "Edit monthly salary", () => EditPick(personal, key, EditChoice.Salary)),
			new MenuItem("D", "Delete", () => EditPick(personal, key, EditChoice.Delete)),
			new MenuItem("B", "Back", ShowAllPersonal),
		};

		ShowMenu(options);
	}

	public void EditPick(Personal personal, string key, EditChoice input)
	{
		switch (input)
		{
			case EditChoice.FirstName:
				personal.ChangeFirstName(
						inputHandler.ValidateStringInput("First name: "));
				break;

			case EditChoice.LastName:
				personal.ChangeLastName(
						inputHandler.ValidateStringInput("Last name: "));
				break;

			case EditChoice.Salary:
				personal.ChangeSalary(
						inputHandler.ValidateDecimalInput("Monthly salary: "));
				break;

			case EditChoice.Delete:
				PersonalList.Remove(personal);
				ShowAllPersonal();
				return;
		}

		ShowSinglePersonal(personal, key);
	}

	public void PersonalTable(List<Personal> personals)
	{
		// detta bad jag ai göra för mig
		Console.WriteLine($"{"Key",-1} | {"Namn",-20} | {"Lön",10}");
		Console.WriteLine(new string('-', 40));

		for (int i = 0; i < personals.Count; i++)
		{
			var personal = PersonalList[i];
			Console.WriteLine($"{i + 1,-3} | {personal.GetFullname(),-20} | {personal.SalaryByMonth,10}");
		}
	}
	public void SinglePersonalTable(Personal personal, int key)
	{
		// detta bad jag ai göra för mig
		Console.WriteLine($"{"Key",-1} | {"Namn",-20} | {"Lön",10}");
		Console.WriteLine(new string('-', 40));

		Console.WriteLine($"{key + 1,-3} | {personal.GetFullname(),-20} | {personal.SalaryByMonth,10}");
	}
}