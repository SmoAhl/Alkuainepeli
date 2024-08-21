using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class ElementTest
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the game!");
        Console.WriteLine("Do you want to play (p) or view results (v)?");
        string choice = Console.ReadLine();
        if (choice == "p")
        {
            Peruspeli();
        }
        else if (choice == "v")
        {
            ViewResults();
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }

    public static void Peruspeli()
    {
        int numberOfElements = 5;  // Kuinka monta alkuainetta kysytään = 5
        List<string> vastaukset = new List<string>(); // tehdään lista vastauksille

        Console.WriteLine($"Anna {numberOfElements} alkuaineen nimeä:");

        for (int i = 0; i < numberOfElements; i++)//Kysytään käyttäjältä viisi kertaa loopia käyttäen
        {
            Console.Write($"Anna alkuaineen nimi {i + 1}: ");//Pyydetään antamaan alkuaineen nimi ja lisätään i arvoon yksi kunnes se on numberofelements(5)
            string input = Console.ReadLine().ToLower().Trim();//Luetaan ja muutetaan vastaus pieniksi kirjaimiksi ja poistetaan turhat välit. 

            if (string.IsNullOrWhiteSpace(input))//Jos vastaus on tyhjä pyydetään käyttäjää yrittämään uudelleen.
            {
                Console.WriteLine("Syöte ei voi olla tyhjä. Yritä uudelleen.");
                i--; // vähennetään i:n arvoa yhdellä, jotta saadaan viisi kunnon vastausta. 
                continue;
            }

            if (vastaukset.Contains(input))//jos vastaus on sama pyydetään käyttäjää yrittämään uudelleen.
            {
                Console.WriteLine("Et voi antaa samaa nimeä kahdesti. Yritä uudelleen.");
                i--; // vähennetään i:n arvoa yhdellä, jotta saadaan viisi kunnon vastausta.
            }
            else
            {
                vastaukset.Add(input);//muuten lisätään vastaukset listaan. 
            }
        }

        string polku = Path.Combine(Directory.GetCurrentDirectory(), "alkuaineet.txt");//Haetaan alkuaineet.txt tiedosto.

        string[] oikeat;
        try
        {
            oikeat = File.ReadAllLines(polku);//Lukee alkuaineet.txt tiedoston.
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Tiedostoa ei löydy. Varmista, että 'alkuaineet.txt' on olemassa.");//Jos alkuaineet.txt tiedostoa ei ole, se oli sitten siinä. 
            return;
        }

        for (int i = 0; i < oikeat.Length; i++)//
        {
            oikeat[i] = oikeat[i].ToLower().Trim();
        }

        List<string> oikeatvastaukset = new List<string>();
        List<string> väärätvastaukset = new List<string>();

        foreach (string item in vastaukset)
        {
            if (Array.Exists(oikeat, element => element == item))//tarkistaa löytyykö 
            {
                oikeatvastaukset.Add(item);
            }
            else
            {
                väärätvastaukset.Add(item);
            }
        }


        Console.WriteLine("\nOikeat vastaukset:");//tekee rivivaihdon kaikille vastauksille, jotka ovat oikeat vastaukset listassa.
        foreach (string item in oikeatvastaukset)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nVäärät vastaukset:");//tekee rivivaihdon kaikille vastauksille, jotka ovat väärät vastaukset listassa.
        foreach (string item in väärätvastaukset)
        {
            Console.WriteLine(item);
        }
    }

    static void ViewResults()
    {

    }

    static void SaveResult()
    {

    }


}
