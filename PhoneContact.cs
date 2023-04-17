using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaPraktyczneKursCSharpZUdemy
{
    internal class PhoneContact
    {
        private static List<Contact> contacts = new List<Contact>();

        public static void Add(Contact newContact)
        {
            Contact? foundContact = FindByNumber(newContact.PhoneNumber);
            if (foundContact == null)
            {
                contacts.Add(newContact);
            }
            else
            {
                Console.WriteLine($"Nie mozna dodac kontaktu, poniewaz kontakt o podanym numerze {newContact.PhoneNumber} istnieje.");
            }
        }

        public static Contact? FindByNumber(string contactNumber)
        {
            foreach (var contact in contacts)
            {
                if (contact.PhoneNumber.Equals(contactNumber, StringComparison.OrdinalIgnoreCase))
                {
                    return contact;
                }
            }
            return null;
        }

        public static List<Contact> FindAll()
        {
            return contacts;
        }

        public static List<Contact> FindByName(string inputName)
        {
            List<Contact> foundContacts = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(inputName,StringComparison.OrdinalIgnoreCase))                  
                {
                    foundContacts.Add(contact);                    
                }
            }
            return foundContacts;
        }

        public static void UpdateContactNumber(Contact oldContact, Contact newContact)
        {
            string updateValidationResult = ValidateUpdate(newContact);

            if (!updateValidationResult.Equals(string.Empty))
            {
                Console.WriteLine("Blad walidacji: " + updateValidationResult);
                return; //return; nie wykonuje ponizszego kodu metody
            }

            if (!newContact.Name.Equals(string.Empty))
            {
                List<Contact> foundContacts = FindByName(newContact.Name);
                if (foundContacts.Count == 1)
                {
                    Contact foundContact = foundContacts.First();
                }
            }
            else if (!newContact.PhoneNumber.Equals(string.Empty))
            {
                Contact? foundContacts = FindByNumber(newContact.PhoneNumber);
                if (foundContacts != null)
                {
                    Contact foundContact = foundContacts;
                }
            }
            else
            {
                throw new Exception("Shoud never happened");
            }
            /*
            IList<Contact> foundContacts = new List<Contact>();

            if (foundContacts.Count == 0)
            {
                Console.WriteLine($"Nie znaleziono kontaktu o nazwie {inputName}");
            }
            else
            {
                foreach (var contact in foundContacts)
                {
                    Console.WriteLine($"Numer {contact.PhoneNumber} nalezy do {contact.Name}.");
                    Console.WriteLine($"Wprowadz nowy numer dla kontaktu {contact.Name}");
                    string inputNewNumber = Console.ReadLine();

                    Contact updatedContact = new Contact(inputName, inputNewNumber);

                    PhoneContact.UpdateContactNumber(contact, updatedContact);

                }

            }
            

            Contact? foundContact = FindByNumber(oldContact.PhoneNumber);
            if (foundContact == null)
            {
                contacts.Remove(oldContact);
                contacts.Add(newContact);
            }
            else
            {
                Console.WriteLine($"Nie mozna poprawic kontakt, blad danych.");
            }
            */
        }

        /* Warunki walidacji:
         * Nazwa kontaktu ma byc unikalna
         * Numer kontaktu musi byc unikalny
         * Aktualizujac kontakt nalezy podac albo nazwe, albo numer (tylko jeden atrybut)
         * 
         * 
         * */
        private static string ValidateUpdate(Contact newContact)
        {
            if (newContact == null)
            {
                return "Kontakt nie moze byc pusty";
            }
            else if(string.IsNullOrEmpty(newContact.Name) && string.IsNullOrEmpty(newContact.PhoneNumber))
            {
                return "Numer i nazwa kontaktu nie moga byc jednoczesnie puste";
            }            
            else if (string.IsNullOrWhiteSpace(newContact.Name))
            {
                ValidateUpdateByNumber(newContact.PhoneNumber);
            }
            else if (string.IsNullOrWhiteSpace(newContact.PhoneNumber))
            {
                ValidateUpdateByName(newContact.Name);
            }
            else
            {
                return "Jednoczesna aktualizacja numeru i nazwy kontaktu nie jest wspierana";
            }

            
            return string.Empty;
        }

        private static string ValidateUpdateByNumber(string newPhoneNumber)
        {
            foreach (var contact in contacts)
            {

                if (contact.PhoneNumber.Equals(newPhoneNumber))
                {
                    return "Taki numer telefonu juz istnieje";
                }
            }
            return string.Empty;
        }

        private static string ValidateUpdateByName(string newName)
        {
            foreach (var contact in contacts)
            {

                if (contact.Name.Equals(newName))
                {
                    return "Taka nazwa kontaktu juz istnieje";
                }
            }
            return string.Empty;

        }
    }
}
