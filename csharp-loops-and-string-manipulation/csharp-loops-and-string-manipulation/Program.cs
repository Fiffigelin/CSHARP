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
          case "2":
            CalculateGroupTicketPrice();
            break;
          case "3":
            PrintOutInputLoop();
            break;
          case "4":
            PrintTheThirdWord();
            break;
          default:
            Console.WriteLine("Felaktig uppgift. Försök igen!");
            Console.ReadLine();
            break;

        }
      }
    }

    /*
     * Skriver menyerna först
     * sedan bryter jag ned funktionalitet
     * som används på flera ställen till mindre testbara funktioner
    */

    // Huvudmenyn:
    static void MainMenu()
    {
      Console.Clear();
      Console.WriteLine("== VÄLKOMMEN TILL HUVUDMENYN ==");
      Console.WriteLine("= Välj ditt val med någon av dessa siffror =");
      Console.WriteLine("[1] Räkna ut biljettpris");
      Console.WriteLine("[2] Räkna ut grupp-pris");
      Console.WriteLine("[3] Loopa ut input 10 gånger");
      Console.WriteLine("[4] Tredje ordet");
      Console.WriteLine("[0] Avsluta");
      Console.WriteLine();
      Console.Write("Var god välj val: ");
    }

    // Case 1:
    // Visar biljettpriset utifrån användarens svar utifrån ålder
    static void ShowTicketPrice()
    {
      int age;
      bool isValid = false;

      Console.Clear();
      Console.WriteLine("== Vänligen ange din ålder med siffror ==");

      do
      {
        Console.Write("Ålder: ");
        string input = Console.ReadLine();

        isValid = int.TryParse(input, out age);

        if(!isValid || age < 0)
        {
          Console.WriteLine("Felaktigt svar. Var god och försök igen.");
        }
      } while(isValid && age < 0);
      
      Console.WriteLine();
      int price = (ReturnPriceByAge(age));

      switch(price)
      {
        case 0:
          Console.WriteLine("Grattis! Du får gå gratis!");
          break;
        case 80:
          Console.WriteLine($"Ungdomspris: {price}kr");
          break;
        case 90:
            Console.WriteLine($"Pensionärspris: {price}kr");
          break;
        case 120:
          Console.WriteLine($"Standardpris: {price}kr");
          break;
        default:
          Console.WriteLine($"Något gick fel.");
          break;
      }

      ReturnToMainMenu();
    }

    // Case 2:
    // Räkna ut biljettpris för ett sällskap beroende på
    // besökarnas antal och ålder
    static void CalculateGroupTicketPrice()
    {
      int visitors;
      int sum = 0;
      bool isValid;

      Console.Clear();
      Console.WriteLine("== Vänligen ange hur många ni är i ert sällskap med siffror ==");
      do
      {
        Console.Write("Antal besökare: ");
        string answer = Console.ReadLine();

        isValid = int.TryParse(answer, out visitors);

        if(!isValid || visitors <= 0)
        {
          Console.WriteLine("Felaktigt svar. Var god och försök igen.");
        }
      } while(!isValid || visitors <= 0);

      for(int i = 0; i < visitors; i++)
      {
        int age;
        do
        {
          Console.Write($"Ålder för gäst {i + 1}: ");
          string input = Console.ReadLine();

          isValid = int.TryParse(input, out age);

          if(!isValid || age < 0)
          {
            Console.WriteLine("Felaktigt svar. Var god och försök igen.");
          }

        } while(!isValid || age < 0);

         sum += ReturnPriceByAge(age);
      }

      Console.WriteLine();
      Console.WriteLine("== SAMMANSTÄLLNING ==");
      Console.WriteLine($"Antal gäster: {visitors}");
      Console.WriteLine($"Summa: {sum}kr");

      ReturnToMainMenu();
    }

    // Case 3:
    // Tar input från användaren som returneras utan radbrytning med numrering
    // vilket skrivs ut 10 gånger
    static void PrintOutInputLoop()
    {
      bool isValid = false;
      string input = string.Empty;

      Console.WriteLine("== SKRIV EN INPUT MED 5 TECKEN ELLER MER ==");
      do
      {
        Console.Write($"Input: ");
        input = Console.ReadLine();

        if(input.Length <= 4)
        {
          Console.WriteLine("Felaktigt svar. Var god och försök igen.");
        }
        else
        {
          isValid = true;
        }
      } while(!isValid);

      Console.WriteLine();

      for(int i = 1; i <= 10; i ++)
      {
        Console.Write($"{i}. {input}. ");
      }

      ReturnToMainMenu();
    }

    // Case 4:
    // Metoden tar in en input av en mening på 3 ord eller mer
    // räknar varje ord och skriver ut 3:e ordet
    static void PrintTheThirdWord()
    {
      bool isValid = false;
      Console.Clear();
      Console.WriteLine("== Vänligen skriv en mening på minst 3 ord ==");

      do
      {
        Console.Write("Din mening: ");
        // läs mer om Split och StringSplitOptions här: https://learn.microsoft.com/en-us/dotnet/standard/base-types/divide-up-strings
        var words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if(words.Length < 3) 
        {
          Console.WriteLine("Inte tillräckligt många ord. Var god och försök igen.");
        }
        else
        {
          // väljer det tredje elementet i arrayen
          string thirdWord = words[2];
          Console.WriteLine(thirdWord);
          isValid = true;
        }

      } while(!isValid);

      ReturnToMainMenu();
    }

    static void ReturnToMainMenu()
    {
      Console.WriteLine();
      Console.WriteLine("Tryck valfri knapp för att återgå till startmenyn");
      Console.ReadLine();
    }

    /* 
     * Refaktorering
     * Returnerar int istället för meddelande
     * för att kunna användas av både case 1 och 2
    */
    static int ReturnPriceByAge(int age)
    {
      if(age < 20)
      {
        if(age < 5)
        {
          return 0;
        }
        else
        {
          return 80;
        }
      } else if(age > 64)
      {
        if(age > 100)
        {
          return 0;
        }
        else
        {
          return 90;
        }
      }
      else
      {
        return 120;
      }
    }
  }
}
