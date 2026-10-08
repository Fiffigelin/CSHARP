using System;

namespace ExceptionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                /*
                * Jag har skapat flera filer för de olika utfallen
                * Bara att kommentera in eller ut vilken man vill testa :)
                * Fick inte de andra filerna att kopieras till \Bin
                * Ändrade från numbers.txt => *.txt i csproj
                */
                Console.WriteLine("=== Start av programmet ===");

                // Exempel 1: try-catch-finally
                try
                {
                    Console.WriteLine("Försöker läsa fil och räkna...");
                    // Ingen exception kastas
                    var path = Path.Combine(AppContext.BaseDirectory, "numbers.txt");

                    // FileNotFoundException
                    // var path = Path.Combine(AppContext.BaseDirectory, "numbers00.txt");
                    
                    // FormatException
                    // var path = Path.Combine(AppContext.BaseDirectory, "format-exception.txt");

                    // DivideByZeroException
                    // var path = Path.Combine(AppContext.BaseDirectory, "divide-by-zero-exception.txt");

                    // Exception
                    //var path = Path.Combine(AppContext.BaseDirectory, "exception.txt");

                    var result = ProcessFile(path);
                  
                    Console.WriteLine($"\nResultat: {result}");
                }
                catch (FileNotFoundException ex)
                {
                    // Specifikt fel om filen inte finns
                    Console.WriteLine($"Filen hittades inte: {ex.Message}");
                }
                catch (FormatException ex)
                {
                    // Specifikt fel om texten inte kan tolkas som tal
                    Console.WriteLine($"Formatfel: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    // Specifikt fel om nolldivision
                    Console.WriteLine($"Kan inte dividera med noll: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Fallback för alla övriga obekanta fel
                    Console.WriteLine($"Okänt fel: {ex.Message}");
                }
                finally
                {
                    // Körs ALLTID, även om det blev undantag
                    Console.WriteLine("Cleanup: Logging avslutat anrop.");
                }

                Console.WriteLine("Programmet avslutas normalt.");
            }

            // Exempel på metod som själv kastar ett undantag (throw)
            static int ProcessFile(string fileName)
            {
                // Om filnamnet är tomt: logiskt fel vi vill signalera
                if (string.IsNullOrWhiteSpace(fileName))
                {
                    throw new ArgumentException("Filnamn får inte vara tomt eller null.", nameof(fileName));
                }

                StreamReader? reader = null;
                try
                {
                    reader = new StreamReader(fileName);

                    string? line = reader.ReadLine();
                    if (line == null)
                        throw new InvalidOperationException("Filen är tom.");

                    // Försöker omvandla text till tal
                    int number = int.Parse(line); // Kan ge FormatException

                    // Division: kan ge DivideByZeroException
                    // DENNA! DENNA DREV MIG TILL VANSINNE!
                    // 100.0 är ju en double XD
                    return 100 / number;
                }

                /* Ingen catch finns kvar i metoden utan det kastas upp till
                 * de andra execptions i Main().
                 */

                finally
                {
                    // Garanterad stängning av resurs
                    reader?.Close();
                    Console.WriteLine("finally i ProcessFile: StreamReader stängd.");
                }
            }
        }
    }
}

