using System;
using System.Text;

public class Program
{

    private const int AlphabetSize = 26;

    private const int AsciiLowerA = 97;
    private const int AsciiLowerZ = 122;


    public static string CaesarCipher(string plaintext, int key)
    {
        StringBuilder ciphertext = new StringBuilder();
        int effectiveKey = key % AlphabetSize;
        if (effectiveKey < 0)
        {
            effectiveKey += AlphabetSize;
        }
        foreach (char charToEncrypt in plaintext)
        {
            if (charToEncrypt == ' ')
            {

                ciphertext.Append(' ');
            }
            else if (charToEncrypt >= AsciiLowerA && charToEncrypt <= AsciiLowerZ)
            {
                int originalPosition = charToEncrypt - AsciiLowerA;
                int newPosition = (originalPosition + effectiveKey) % AlphabetSize;
                char encryptedChar = (char)(newPosition + AsciiLowerA);

                ciphertext.Append(encryptedChar);
            }
            else
            {
                ciphertext.Append(charToEncrypt);
            }
        }

        return ciphertext.ToString();
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Szyfr Cezara (C#) ---");
        Console.WriteLine("Program szyfrujący małe litery alfabetu łacińskiego (a-z).");
        Console.WriteLine("Spacje pozostają niezmienione.");
        Console.WriteLine(new string('-', 30));

        string plaintext;
        int key = 0;
        bool keyIsValid = false;


        Console.Write("Wprowadź tekst jawny (tylko małe litery i spacje): ");
        plaintext = Console.ReadLine()?.ToLower() ?? string.Empty;
        while (!keyIsValid)
        {
            Console.Write("Wprowadź klucz szyfrowania (liczba całkowita): ");
            string keyInput = Console.ReadLine();

            if (int.TryParse(keyInput, out key))
            {
                keyIsValid = true;
            }
            else
            {
                Console.WriteLine("Błąd: Klucz musi być liczbą całkowitą. Spróbuj ponownie.");
            }
        }


        string ciphertext = CaesarCipher(plaintext, key);

        Console.WriteLine(new string('-', 30));
        Console.WriteLine($"Tekst jawny:        {plaintext}");
        Console.WriteLine($"Klucz (k):          {key}");
        Console.WriteLine($"Tekst zaszyfrowany: {ciphertext}");
        Console.WriteLine(new string('-', 30));

        Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
        Console.ReadKey();
    }
}