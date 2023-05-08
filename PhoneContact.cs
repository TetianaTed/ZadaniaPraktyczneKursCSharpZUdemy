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

        public static void UpdateContactByName(Contact newContact)
        {
            string validationResult = ValidateUpdateByName(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {
                Console.WriteLine("Aktualizacja nie jest mozliwa. Szczegóły: " + validationResult);
                return;
            }

            Contact? foundContact = FindByName(newContact.Name).FirstOrDefault();

            if (foundContact == null)
            {
                Console.WriteLine($"Nie znaleziono kontaktu z nazwa {newContact.Name}");
                return;
            }

            foundContact.PhoneNumber = newContact.PhoneNumber;

            Console.WriteLine($"Kontakt o nazwie {newContact.Name} zostal zaktualizowany.");

        }

        public static void UpdateContactByNumber(Contact newContact)
        {
            string validationResult = ValidateUpdateByNumber(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {
                Console.WriteLine("Aktualizacja nie jest mozliwa. Szczegóły: " + validationResult);
                return;
            }

            Contact? foundContact = FindByNumber(newContact.PhoneNumber);

            if (foundContact == null)
            {
                Console.WriteLine($"Nie znaleziono kontaktu z numerem {newContact.PhoneNumber}");
                return;
            }

            foundContact.Name = newContact.Name;

            Console.WriteLine($"Kontakt z numerem {newContact.PhoneNumber} zostal zaktualizowany.");
        }


        public static void UpdateContactNumber(Contact oldContact, Contact newContact)
        {
            string updateValidationResult = null; // ValidateUpdate(newContact);

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
         * */

        private static string ValidateUpdateByNumber(Contact newContact)
        {
            string technicalValidationResult = ValidateTechnicalUpdate(newContact);

            if (!string.IsNullOrEmpty(technicalValidationResult))
            {
                return technicalValidationResult;
            }

            Contact? foundContact = FindByNumber(newContact.PhoneNumber);
            if (foundContact != null)
            {
                return "Taki numer telefonu juz istnieje";
            }

            return string.Empty;
        }

        private static string ValidateUpdateByName(Contact newContact)
        {
            string technicalValidationResult = ValidateTechnicalUpdate(newContact);

            if (!string.IsNullOrEmpty(technicalValidationResult))
            {
                return technicalValidationResult;
            }
         
            Contact? foundContact = FindByName(newContact.Name).FirstOrDefault();
            if (foundContact != null)
            {
                return "Taka nazwa kontaktu juz istnieje";
            }

            return string.Empty;

        }

        private static string ValidateTechnicalUpdate(Contact newContact)
        {
            if (newContact == null)
            {
                return "Kontakt nie moze byc pusty";
            }
            else if (string.IsNullOrEmpty(newContact.Name) || string.IsNullOrEmpty(newContact.PhoneNumber))
            {
                return "Numer i nazwa kontaktu nie moga byc puste";
            }

            return string.Empty;
        }
    }
}
