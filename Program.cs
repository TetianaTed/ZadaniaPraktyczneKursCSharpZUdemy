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
            int choosedOptionNumber;

            do
            {
                Console.WriteLine("Witam w ksiace telefonicznej. Proszę wybierz jedna z ponizszych opcji wprowadzajac odpowiednia liczbe: \n" +
                    "1 - Dodaj kontakt;\n" +
                    "2 - Wyswietl kontakt na podstawie numeru;\n" +
                    "3 - Wyswietl wszystkie kontakty;\n" +
                    "4 - Wyszukac kontakty dla danej nazwy.\n" +
                    "0 - Wyjscie z programu");

                string choosedOption = Console.ReadLine();
                bool succeedParseChossedOption;
                succeedParseChossedOption = int.TryParse(choosedOption, out choosedOptionNumber);
                if (choosedOptionNumber == 1)
                {
                    AddContact();
                }
                else if (choosedOptionNumber == 2)
                {
                    ShowContactByNumber();
                }
                else if (choosedOptionNumber == 3)
                {
                    ShowAllContacts();
                }
                else if (choosedOptionNumber == 4)
                {
                    ShowContactByName();
                }
            } while (choosedOptionNumber != 0);

        }

        private static void AddContact()
        {
            Console.WriteLine("Wprowadz prosze nazwe kontaktu.");

            string contactName = Console.ReadLine();

            Console.WriteLine("Prosze wprowadz numer telefonu");

            string contactNumber = Console.ReadLine();

            Contact cretedContact = new Contact(contactName, contactNumber);

            PhoneContact.Add(cretedContact);
        }

       private  static void ShowContactByNumber()
        {
            Console.WriteLine("Proszę podaj numer telefonu");

            string inputUserPhoneNumber = Console.ReadLine();

            Contact? foundContact = PhoneContact.FindByNumber(inputUserPhoneNumber);

            if (foundContact == null)
            {
                Console.WriteLine($"Nie znaleziono kontaktu o numerze {inputUserPhoneNumber}");
            }
            else
            {
                Console.WriteLine($"Numer {inputUserPhoneNumber} nalezy do {foundContact.Name}.");
            }
        }

        private static void ShowAllContacts()
        {
            List<Contact> foundAllContacts = PhoneContact.FindAll();

            foreach (var contact in foundAllContacts)
            {
                Console.WriteLine(contact);
            }
        }

        private static void ShowContactByName()
        {
            Console.WriteLine("Proszę podaj nazwe kontaktu");

            string inputName = Console.ReadLine();

            List<Contact> foundContacts = PhoneContact.FindByName(inputName);

            if (foundContacts.Count == 0)
            {
                Console.WriteLine($"Nie znaleziono kontaktu o nazwie {inputName}");
            }
            else
            {
                foreach (var contact in foundContacts)
                {
                    Console.WriteLine($"Numer {contact.PhoneNumber} nalezy do {contact.Name}.");
                }
                
            }
        }

    }
}