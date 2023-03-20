using System.Globalization;
using System.Xml.Linq;

namespace ZadaniaPraktyczneKursCSharpZUdemy
{
    internal class Program
    {
        /*
        Zadanie:
        Utwórz aplikację konsolową która imituję zachowanie aplikacji z kontaktami na telefonie.
        Kontakt to: nazwa i numer telefonu.
        Aplikacja powinna:
        Dodawać kontakty
        Wyświetlić kontakt na podstawie numeru
        Wyświetlić wszystkie kontakty
        Wyszukać kontakty dla danej nazwy
        */

        static void Main(string[] args)
        {
            Menu();


        }

        static void Menu()
        {
            Console.WriteLine("Witam w ksiace telefonicznej. Proszę wybierz jedna z ponizszych opcji wprowadzajac odpowiednia liczbe: \n" +
                "1 - Dodaj kontakt;\n" +
                "2 - Wyswietl kontakt na podstawie numeru;\n" +
                "3 - Wyswietl wszystkie kontakty;\n" +
                "4 - Wyszukac kontakty dla danej nazwy.\n");

            string wybranaOpcja = Console.ReadLine();
            bool TryParseWybranaOpcja;
            int wybranaOpcjaLiczbowa;
            TryParseWybranaOpcja = int.TryParse(wybranaOpcja, out wybranaOpcjaLiczbowa);
            if (wybranaOpcjaLiczbowa == 1)
            {
                DodajKontakt();
            }
        }

        static void DodajKontakt()
        {
            Console.WriteLine("Wprowadz prosze nazwe kontaktu.");

            string nazwaKontaktu = Console.ReadLine();

            Console.WriteLine("Prosze wprowadz numer telefonu");

            string numerTelefonu = Console.ReadLine();

            List<Contact> primeNumbers = new List<Contact>()
            { new Contact(name: "Ola", phoneNumber: "52325698745"),
              new Contact(name: "Marcin", phoneNumber: "126455")
              };

            Console.WriteLine(primeNumbers.First().Name); //primeNumbers.First() = this w klasie contact, bo dzialam na obiekcie Ola

            Console.WriteLine(primeNumbers.First()); // Console.WriteLine(primeNumbers.First().ToString()); ToString() robi sie domyslnie

            Contact contact = new Contact(name: "Michal", phoneNumber: "123456789");
            contact.ToString(); //  contact.ToString() = this w klasie contact, bo dzialam na obiekcie Michal
            Contact testtik = Contact.Test("testowyString"); //jak statyczna metoda to nazwaklasy.nazwa metody. Nie wylolalam na obiekcie, nie bylo new. Nie bylo inicjilizacji obiektu, to nie ma this.
            Console.WriteLine(testtik);

            Console.WriteLine(primeNumbers.First().ToString());

            /*
            primeNumbers.Add(1,5);
            primeNumbers.Add(1); // adding elements using add() method
            primeNumbers.Add(3);
            */

        }
    }
}