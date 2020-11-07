using System;
using System.IO;

namespace Predizione_inserimento
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tasto = default;
            bool esci = default;
            string paragrafo = default;
            string[] dizionario = File.ReadAllText("parole.txt").Split("\n");
            Console.Write("Testo: ");
            do
            {
                tasto = Console.ReadKey(true);
                if (tasto.Key == ConsoleKey.Enter && paragrafo != null)
                {
                    esci = true;
                }
                else if (tasto.Key == ConsoleKey.Backspace && paragrafo != null && paragrafo.Length > 0)
                {
                    paragrafo = paragrafo.Remove(paragrafo.Length - 1);
                    Console.Write(" \b");
                }
                else
                {
                    paragrafo += tasto.KeyChar.ToString();
                }

                Console.Clear();
                Console.Write("Testo: " + paragrafo);
                if(paragrafo.Length > 1)
                {
                    int x = default;
                    string suggerimento = default;
                    while(x < dizionario.Length)
                    {
                        if (dizionario[x].StartsWith(paragrafo))
                        {
                            suggerimento = dizionario[x];
                            Console.Write("\nSuggerimento: " + suggerimento);
                            break;
                        }

                        x++;
                    }
                    
                }
            } while (esci == false);
            Console.WriteLine("Premi un tasto per chiudere il programma...");
            Console.ReadKey();
        }
    }
}
