using System;
using Tsbe.CodeCracker;

namespace PasswordCrackerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan bir parola girmesini isteyin
            Console.WriteLine("Bitte Passwort eingeben:");
            string password = Console.ReadLine();
            
            // Paroladan hash kodu oluşturun
            string hash = MD5Hash.GeneratePassword(password);
            Console.WriteLine($"Ihr Passwort als Hashcode ist: {hash}");
            
            // Maksimum deneme uzunluğunu kullanıcıdan alın
            Console.WriteLine("Bitte maximale Länge eingeben:");
            if (int.TryParse(Console.ReadLine(), out int maxLength))
            {
                // Tüm olasılıkları deneme sürecini başlat
                bool found = false;
                for (int i = 0; i <= maxLength; i++)
                {
                    // Sayıyı string olarak al ve hash kodunu oluştur
                    string attempt = i.ToString();
                    string attemptHash = MD5Hash.GeneratePassword(attempt);

                    // Eğer hash kodu eşleşirse MATCH, değilse No Match
                    if (attemptHash == hash)
                    {
                        Console.WriteLine($"{attempt} -> MATCH");
                        Console.WriteLine($"Das Passwort wurde gecrackt: {attempt}");
                        found = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{attempt} -> No Match");
                    }
                }

                // Eğer döngü sonunda hiçbir eşleşme bulunamadıysa
                if (!found)
                {
                    Console.WriteLine("Das Passwort konnte nicht gefunden werden.");
                }
            }
            else
            {
                Console.WriteLine("Ungültige Länge eingegeben.");
            }
        }
    }
}
