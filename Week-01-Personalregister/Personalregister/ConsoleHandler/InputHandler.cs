namespace Personalregister.ConsoleHandler;

public class InputHandler
{
  public void ErrorMessage()
  {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("The field cannot be empty.");
    Console.WriteLine();
    Console.ResetColor();
  }

  public string ValidateStringInput(string message)
  {
    while (true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      // Jag tänker att ett namn INTE ska innehålla siffror MEN det kanske finns namn med siffror?
      // Samma sak med namnets längd...
      // if (!string.IsNullOrWhiteSpace(input) && input.All(char.isLetter))
      if (!string.IsNullOrWhiteSpace(input))
      {
        return input;
      }

      ErrorMessage();
    }
  }

  public decimal ValidateDecimalInput(string message)
  {
    while (true)
    {
      Console.Write(message);
      string? input = Console.ReadLine();

      if (decimal.TryParse(input, out decimal result))
      {
        if (result > 0)
        {
          return result;
        }
      }

      ErrorMessage();
    }
  }
}