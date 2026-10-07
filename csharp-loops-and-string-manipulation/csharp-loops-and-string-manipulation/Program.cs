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
          default:
            Console.WriteLine("Felaktig uppgift. Försök igen!");
            Console.ReadLine();
            break;

        }
      }
    }

    // Skriver menyerna först
    // sedan bryter jag ned funktionalitet som används på flera ställen till mindre testbara funktioner

    // Huvudmenyn:
    static void MainMenu()
    {
      Console.Clear();
      Console.WriteLine("== VÄLKOMMEN TILL HUVUDMENYN ==");
      Console.WriteLine("= Välj ditt val med någon av dessa siffror =");
      Console.WriteLine("[1] Räkna ut biljettpris");
      Console.WriteLine("[2] Räkna ut grupp-pris");
      Console.WriteLine("[0] Avsluta");
      Console.WriteLine();
    }

    // Case 1:
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
      ReturnPriceMessage(ReturnPriceByAge(age));

      Console.WriteLine();
      Console.WriteLine("Tryck valfri knapp för att återgå till startmenyn");
      Console.ReadLine();

      MainMenu();
    }

    // Case 2:
    // Räkna ut grupp-pris för ett sällskap
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

        if(!isValid)
        {
          Console.WriteLine("Felaktigt svar. Var god och försök igen.");
        }

      } while(!isValid);

      for(int i = 0; i < visitors; i++)
      {
        do
        {
          Console.Write($"Ålder för gäst {i+1}: ");
          string input = Console.ReadLine();

          isValid = int.TryParse(input, out int age);

          if(!isValid)
          {
            Console.WriteLine("Felaktigt svar. Var god och försök igen.");
          }
          else
          {
            sum += ReturnPriceByAge(age);
          }
        } while(!isValid);
      }

      Console.WriteLine();
      Console.WriteLine("== SAMMANSTÄLLNING ==");
      Console.WriteLine($"Antal gäster: {visitors}");
      Console.WriteLine($"Summa: {sum}kr");

      Console.WriteLine();
      Console.WriteLine("Tryck valfri knapp för att återgå till startmenyn");
      Console.ReadLine();

      MainMenu();
    }

    // Refaktorering:
    // Returnerar int istället för meddelande för att kunna användas av både case 1 och 2
    static int ReturnPriceByAge(int age)
    {
      if(age < 20)
      {
        return 80;
      }
      else if(age > 64)
      {
        return 90;
      }
      else
      {
        return 120;
      }
    }

    // Refactorering
    // Denna if kan ju egentligen ligga i case 1 metoden.
    // kanske flyttar in den där...
    // det är lättare att testa funktionalitet om metoderna är mindre
    static void ReturnPriceMessage(int price)
    {
      if(price == 80)
      {
        Console.WriteLine($"Ungdomspris: {price}kr");
      }
      else if(price == 90)
      {
        Console.WriteLine($"Pensionärspris: {price}kr");
      }
      else
      {
        Console.WriteLine($"Standardpris: {price}kr");
      }
    }
  }
}
