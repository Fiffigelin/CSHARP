using System;

/* 
  Inget test denna gång och så enkelt det bara går.
*/
namespace csharp_loops_and_string_manipulation
{
  internal class Program
  {
    static void Main(string[] args)
    {
      bool isRunning = true;

      while(isRunning)
      {
        MainMenu();
        string choice = Console.ReadLine();

        switch(choice)
        {
          case "0":
            isRunning = false;
            break;
          default:
            Console.WriteLine("Felaktig uppgift. Försök igen!");
            Console.ReadLine();
            break;

        }
      }
    }

    static void MainMenu()
    {
      Console.Clear();
      Console.WriteLine("== VÄLKOMMEN TILL HUVUDMENYN ==");
      Console.WriteLine("= Välj ditt val med någon av dessa siffror =");
      Console.WriteLine("[0] Avsluta");
    }
  }
}
