namespace Personalregister.ConsoleHandler;

public class MenuItem
{
	public Guid Id { get; set; }
	public ItemKey Key { get; set; }
	public string Label { get; set; }
	public Action Action { get; set; }

	public enum ItemKey
	{
		A, //ADD
		V, //VIEW
		S, //SAVE
		E, //EXIT
		B, //BACK
	}

	public MenuItem(ItemKey key, string label, Action action)
	{
		Id = Guid.NewGuid();
		Key = key;
		Label = label;
		Action = action;
	}
}
public class MenuHandler()
{

	public void ShowMenu(List<MenuItem> options)
	{
		foreach (MenuItem option in options)
		{
			if (option.Key == MenuItem.ItemKey.E)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"[{option.Key}] {option.Label}");
				Console.ResetColor();
			}
			else if (option.Key == MenuItem.ItemKey.B)
			{
				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine($"[{option.Key}] {option.Label}");
				Console.ResetColor();
			}
			else if (option.Key == MenuItem.ItemKey.S)
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
		Console.WriteLine();
		Console.Write("Välj: ");
		var pick = Console.ReadLine();

		var option = options.FirstOrDefault(o => o.Key.ToString() == pick?.ToUpper());
		while (true)
		{
			if (option.Id != Guid.Empty)
			{
				option.Action();
				return;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Something went wrong");
				Console.ResetColor();
				Console.Write("Välj: ");
				pick = Console.ReadLine();
			}
		}
	}
}