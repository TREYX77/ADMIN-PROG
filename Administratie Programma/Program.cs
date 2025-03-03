using System;
using System.Collections.Generic;
using System.Threading;

namespace Administratie_Programma
{
    internal class Program
    {
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static List<Client> clients = new List<Client>();

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
                    Console.Clear();
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
                Console.Clear();

                if (keuze == "1")
                {
                    ClientManagement();
                }
                else if (keuze == "2")
                {
                    ClientInfo();
                }
                else if (keuze == "3")
                {
                    OrderManagement();
                }
                else if (keuze == "4")
                {
                    InvoiceManagement();
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
            Console.WriteLine("Registratie laadt...");
            Thread.Sleep(1300);

            if (!users.ContainsKey(username))
            {
                users.Add(username, password);
                Console.WriteLine("Registratie succesvol!");
                Thread.Sleep(900);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Gebruikersnaam bestaat al.");
                Thread.Sleep(900);
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
                Thread.Sleep(900);
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Username/password incorrect");
                Thread.Sleep(1300);
                Console.Clear();
                return false;
            }
        }

        private static void ClientManagement()
        {
            Console.Clear();
            Console.WriteLine("Klanten beheren");
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("1. Klant toevoegen");
            Console.WriteLine("2. Klant verwijderen");
            Console.WriteLine("3. Klant bewerken");
            Console.WriteLine("4. Terug");
            string keuze = Console.ReadLine();

            if (keuze == "1")
            {
                Console.Write("Voornaam: ");
                string voornaam = Console.ReadLine();
                Console.Clear();
                Console.Write("Achternaam: ");
                string achternaam = Console.ReadLine();
                Console.Clear();
                Console.Write("Adres: ");
                string adres = Console.ReadLine();
                Console.Clear();
                Console.Write("Telefoonnummer: ");
                string telefoonnummer = Console.ReadLine();
                clients.Add(new Client { Voornaam = voornaam, Achternaam = achternaam, Adres = adres, Telefoonnummer = telefoonnummer });
                Console.Clear();
            }
            else if (keuze == "2")
            {
                Console.Write("Voornaam: ");
                string voornaam = Console.ReadLine();
                Console.Clear();
                clients.RemoveAll(c => c.Voornaam == voornaam);
                Console.Clear();
            }
            else if (keuze == "3")
            {
                EditClient();
            }
            else
            {
                Console.Clear();
            }
        }

        private static void EditClient()
        {
            Console.Write("Voornaam van de klant die u wilt bewerken: ");
            string voornaam = Console.ReadLine();
            Console.Clear();
            Client client = clients.Find(c => c.Voornaam == voornaam);

            if (client != null)
            {
                Console.Write("Nieuwe voornaam: ");
                client.Voornaam = Console.ReadLine();
                Console.Clear();
                Console.Write("Nieuwe achternaam: ");
                client.Achternaam = Console.ReadLine();
                Console.Clear();
                Console.Write("Nieuw adres: ");
                client.Adres = Console.ReadLine();
                Console.Clear();
                Console.Write("Nieuw telefoonnummer: ");
                client.Telefoonnummer = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Klantgegevens bijgewerkt!");
                Thread.Sleep(900);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Klant niet gevonden.");
                Thread.Sleep(900);
                Console.Clear();
            }
        }

        private static void ClientInfo()
        {
            Console.Clear();
            Console.WriteLine("Klant info");
            Thread.Sleep(2000);

            if (clients.Count == 0)
            {
                Console.WriteLine("Geen klanten gevonden.");
            }
            else
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"Voornaam: {client.Voornaam}, Achternaam: {client.Achternaam}, Adres: {client.Adres}, Telefoonnummer: {client.Telefoonnummer}");
                }
            }
        }

        private static void OrderManagement()
        {
            Console.Clear();
            Console.WriteLine("Bestellingen beheren...");
            Thread.Sleep(1500);

            if (clients.Count == 0)
            {
                Console.WriteLine("Geen klanten gevonden om te bewerken.");
            }
            else
            {
                foreach (var client in clients)
                {
                    Console.WriteLine($"Klant: {client.Voornaam}, {client.Achternaam}");
                }
                Console.Write("Kies een klant: ");
                string klantKeuze = Console.ReadLine();
                Thread.Sleep(500);
                Console.Clear();
                Console.WriteLine("Geen bestellingen gevonden.");
                Thread.Sleep(900);
                Console.WriteLine("Kies ander klant..");
                Thread.Sleep(1500);
                Console.Clear();
                return;
            }
        }

        private static void InvoiceManagement()
        {
            Console.Clear();
            Console.WriteLine("Facturen beheren");
            Thread.Sleep(2000);
            Console.Clear();
        }
    }

    internal class Client
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Telefoonnummer { get; set; }
    }
}
