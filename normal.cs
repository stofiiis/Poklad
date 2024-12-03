using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poklad1
{
    public class Normal
    {
        public void Hra()
        {
            int[,] array =
            {
            {1, 2, 3, 4, 5},
            {6, 7, 8, 9, 10},
            {11, 12, 13, 14, 15 },
            {16, 17, 18, 19, 20 },
            {21, 22, 23, 24, 25 },
            };
            //ziskavani pozece pro poklad
            Random random = new();
            int radek = random.Next(0, array.GetLength(0));
            int sloupec = random.Next(0, array.GetLength(1));
            int poklad = array[radek, sloupec];
            int kamen;
            do
            {
                radek = random.Next(0, array.GetLength(0));
                sloupec = random.Next(0, array.GetLength(1));
                kamen = array[radek, sloupec];
            } while (kamen == poklad);

            int srdicko;
            do
            {
                radek = random.Next(0, array.GetLength(0));
                sloupec = random.Next(0, array.GetLength(1));
                srdicko = array[radek, sloupec];
            } while (srdicko == poklad || srdicko == kamen);
            Console.WriteLine(srdicko);

            string posledniPoz = "";
            int score = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Počet odehraných tahů: {score}");

                // If there is a direction hint from the last move, print it
                if (!string.IsNullOrEmpty(posledniPoz))
                {
                    Console.WriteLine(posledniPoz);
                }
                Console.WriteLine("");
                Console.WriteLine("Napiš pozici na kterou chceš jít (1-25)");
                int pozice = int.Parse(Console.ReadLine()!);
                if (pozice > 25 || pozice < 1)
                {
                    Console.WriteLine("Nemůžeš mimo mapu! Vyber si číslo od 1 do 25!");
                    continue;
                }

                score++;

                if (pozice == kamen)
                {
                    Console.WriteLine("Narazil jsi na kamen a zlomil jsi lopatu! Konec hry.");
                    Creds creds = new();
                    creds.WriteCreds();
                    break;
                }
                if (pozice == srdicko)
                {
                    Console.WriteLine("Našel jsi srdíčko a odečítá se ti jeden tah!");
                    score--;
                    continue;

                }
                if (poklad == pozice)
                {
                    Console.WriteLine("Vyhrál jsi");
                    Creds creds1 = new();
                    creds1.WriteCreds();
                    break;
                }

                //urcuje radky a sloupce hrace a pokladu
                int pokladRadek = (poklad - 1) / 5;
                int pokladSloupec = (poklad - 1) % 5;
                int hracRadek = (pozice - 1) / 5;
                int hracSloupec = (pozice - 1) % 5;
                //rekne hraci kam ma jit
                if (hracRadek < pokladRadek && hracSloupec == pokladSloupec)
                    posledniPoz = "Poklad je směrem na jih.";
                else if (hracRadek > pokladRadek && hracSloupec == pokladSloupec)
                    posledniPoz = "Poklad je směrem na sever.";
                else if (hracSloupec < pokladSloupec && hracRadek == pokladRadek)
                    posledniPoz = "Poklad je směrem na východ.";
                else if (hracSloupec > pokladSloupec && hracRadek == pokladRadek)
                    posledniPoz = "Poklad je směrem na západ.";
                else if (hracRadek < pokladRadek && hracSloupec < pokladSloupec)
                    posledniPoz = "Poklad je směrem na jihovýchod.";
                else if (hracRadek < pokladRadek && hracSloupec > pokladSloupec)
                    posledniPoz = "Poklad je směrem na jihozápad.";
                else if (hracRadek > pokladRadek && hracSloupec < pokladSloupec)
                    posledniPoz = "Poklad je směrem na severovýchod.";
                else if (hracRadek > pokladRadek && hracSloupec > pokladSloupec)
                    posledniPoz = "Poklad je směrem na severozápad.";
            }
    }   }
}
