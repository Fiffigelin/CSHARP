namespace Personalregister.ConsoleHandler;

public class InputHandler
{
  public string ValidateStringInput(string message)
  {
    while (true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (!string.IsNullOrWhiteSpace(input))
      {
        return input;
      }

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("The field cannot be empty.");
      Console.WriteLine();
      Console.ResetColor();
    }
  }
}