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
          case "1":
            ShowTicketPrice();

            break;
          default:
            Console.WriteLine("Felaktig uppgift. Försök igen!");
            Console.ReadLine();
            break;

        }
      }
    }

    // Skriver menyerna först
    // sedan bryter jag ned funktionalitet som används på flera ställen till mindre testbara funktioner
    static void MainMenu()
    {
      Console.Clear();
      Console.WriteLine("== VÄLKOMMEN TILL HUVUDMENYN ==");
      Console.WriteLine("= Välj ditt val med någon av dessa siffror =");
      Console.WriteLine("[1] Räkna ut biljettpris");
      Console.WriteLine("[0] Avsluta");
      Console.WriteLine();
    }

    // Visar biljettpriset utifrån användarens svar angående ålder
    static void ShowTicketPrice()
    {
      int age;
      bool isValid;

      Console.Clear();
      Console.WriteLine("== Vänligen ange din ålder med siffror ==");

      do
      {
        Console.Write("Ålder: ");
        string input = Console.ReadLine();

        isValid = int.TryParse(input, out age);

        if(!isValid)
        {
          Console.WriteLine("Felaktigt svar. Var god och försök igen.");
        }
      } while(!isValid); // samma sak som isValid == false
      
      Console.WriteLine();
      Console.WriteLine("Du behöver betala detta biljettpris.");
      ReturnPriceByAge(age);

      Console.WriteLine();
      Console.WriteLine("Tryck valfri knapp för att återgå till startmenyn");
      Console.ReadLine();

      MainMenu();
    }


    static void ReturnPriceByAge(int age)
    {
      string message = string.Empty;
      if(age < 20)
      {
        message = "Ungdomspris: 80kr";
      }
      else if(age > 64)
      {
        message = "Pensionärspris: 90kr";
      }
      else
      {
        message = "Standardpris: 120kr";
      }

      Console.WriteLine(message);
    }
  }
}
