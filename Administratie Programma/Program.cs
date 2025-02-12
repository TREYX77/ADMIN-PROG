using System;
using System.Collections.Generic;

namespace Administratie_Programma
{
    internal class Program
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welkom bij het administratie programma!");
                Console.WriteLine("Wat wilt u doen?");
                Console.WriteLine("1. Inloggen");
                Console.WriteLine("2. Registreren");
                Console.WriteLine("3. Afsluiten");
                Console.Write("Keuze: ");
                string keuzeMenu = Console.ReadLine()?.ToLower();
                Console.Clear();

                if (keuzeMenu == "1")
                {
                    if (Login())
                    {
                        Console.Clear();
                        break;
                    }
                }
                else if (keuzeMenu == "2")
                {
                    Console.Clear();
                    Register();
                }
                else if (keuzeMenu == "3")
                {
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Kies tussen 1, 2, 3");
                }
            }

            while (true)
            {
                Console.WriteLine("Welkom bij het administratie programma!");
                Console.WriteLine("Wat wilt u doen?");
                Console.WriteLine("1. Klanten beheren");
                Console.WriteLine("2. Klant info");
                Console.WriteLine("3. Bestellingen beheren");
                Console.WriteLine("4. Facturen beheren");
                Console.WriteLine("5. Afsluiten");
                Console.Write("Keuze: ");
                string keuze = Console.ReadLine()?.ToLower();
                if (keuze == "1")
                {
                    Console.WriteLine("Klanten beheren");
                }
                else if (keuze == "2")
                {
                    Console.WriteLine("Klant info");
                }
                else if (keuze == "3")
                {
                    Console.WriteLine("Bestellingen beheren");
                }
                else if (keuze == "4")
                {
                    Console.WriteLine("Facturen beheren");
                }
                else if (keuze == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Kies tussen 1, 2, 3, 4, 5");
                }
            }
        }

        private static void Register()
        {
            Console.WriteLine("Registreren");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Clear();

            if (!users.ContainsKey(username))
            {
                users.Add(username, password);
                Console.WriteLine("Registratie succesvol!");
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Gebruikersnaam bestaat al.");
                Console.Clear();
            }
        }

        private static bool Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Clear();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Clear();

            if (users.ContainsKey(username) && users[username] == password)
            {
                Console.WriteLine("Inloggen succesvol!");
                return true;
            }
            else
            {
                Console.WriteLine("Username/password incorrect");
                return false;
            }
        }
    }
}
