using System.IO;
namespace sieci_quiz;

class Program
{
    static void Main(string[] args)
    {
        
        string baza = File.ReadAllText($"{Environment.ProcessPath}/../BazaPytan.txt");
        
        List<string> Pytania = new List<string>();
        foreach (string part in baza.Split("\n"))
        {
            Pytania.Add(part);
        }

        Random rnd = new Random();
        while (Pytania.Count > 0)
        {
            PrintQuestion(rnd.Next(0, Pytania.Count), Pytania);
            Console.Clear();

        }
    }

    static void PrintQuestion(int questionNumber, List<string> Pytania)
    {
        Console.WriteLine($"Pozostalych pytan: {Pytania.Count}\n\n");
        string[] data = Pytania[questionNumber].Split('|');
        foreach (string s in data[0].Split(';'))
        {
            Console.WriteLine(s);
        }

        Console.Write("Odpowiedz: ");
        if (data[1].Trim() == Console.ReadLine().ToUpper())
        {
            Console.Clear();
            Console.WriteLine("Prawidlowa odpowiedz! Nacisnij przycisk aby przejsc dalej...");
            Pytania.RemoveAt(questionNumber);
            Console.ReadKey();
        }
        else
        {
            // /Console.Clear();
            Console.WriteLine("Bledna odpowiedz! Prawidlowa odpowiedz to {0}", data[1]);
            Console.ReadKey();
        }
    }
}