using Poklad1;

int neco = 0;
while (neco == 0)
{
    Console.WriteLine("Vyber si obtížnost: Jednoduchá, Normální, Těžká (pro ukončení napiš konec)");
    Console.WriteLine("Tvůj výběr:");
    string select = Console.ReadLine()!;
    if (select == "konec" || select == "Konec") {
        Console.WriteLine("konec hry");
        break;
    }
    if (select == "Jednoduchá" || select == "jednoducha" || select == "jednoduchá")
    {
        Jednoduche jednoduche = new();
        jednoduche.Hra();
        neco++;
    }

    else if (select == "Normální" || select == "normální" || select == "normalni" || select == "normal")
    {
        Normal normal = new();
        normal.Hra();
        neco++;
    }
    else if (select == "Těžká" || select == "těžká" || select == "tezka" || select == "hard")
    {
        Tezke tezke = new ();
        tezke.Hra();
        neco++;
    }
    else
        Console.Clear();
        Console.WriteLine("Nezadal jsi správnou obtížnost!");
        
}