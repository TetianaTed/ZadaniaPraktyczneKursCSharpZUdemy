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
            string validationResult = ValidateCreate(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {
                Console.WriteLine("Dodanie kontaktu nie jest mozliwe. Szczegóły: " + validationResult);
                return;
            }

            contacts.Add(newContact);

            Console.WriteLine("Dodano nowy kontakt.");

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

        /* Warunki walidacji:
         * Nazwa kontaktu ma byc unikalna
         * Numer kontaktu musi byc unikalny
         * */

        private static string ValidateUpdateByNumber(Contact newContact)
        {
            string technicalValidationResult = ValidateTechnical(newContact);

            if (!string.IsNullOrEmpty(technicalValidationResult))
            {
                return technicalValidationResult;
            }

            Contact? foundContact = FindByName(newContact.Name).FirstOrDefault();
            if (foundContact != null)
            {
                return "Taka nazwa kontaktu juz istnieje";
            }

            if (FindByNumber(newContact.PhoneNumber) == null)
            {
                return $"Nie znaleziono kontaktu o numerze {newContact.PhoneNumber}";
            }

            return string.Empty;
        }

        private static string ValidateUpdateByName(Contact newContact)
        {
            string technicalValidationResult = ValidateTechnical(newContact);

            if (!string.IsNullOrEmpty(technicalValidationResult))
            {
                return technicalValidationResult;
            }
 
            Contact? foundContact = FindByNumber(newContact.PhoneNumber);
            if (foundContact != null)
            {
                return "Taki numer telefonu juz istnieje";
            }
            
            if (FindByName(newContact.Name).Count == 0)
            {
                return $"Nie znaleziono kontaktu o nazwie {newContact.Name}";      
            }

            return string.Empty;

        }

        private static string ValidateTechnical(Contact newContact)
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

        private static string ValidateCreate(Contact newContact)
        {
            string technicalValidationResult = ValidateTechnical(newContact);

            if (!string.IsNullOrEmpty(technicalValidationResult))
            {
                return technicalValidationResult;
            }

            Contact? foundContactNumber = FindByNumber(newContact.PhoneNumber);
            if (foundContactNumber != null)
            {
                return "Taki numer telefonu juz istnieje";
            }

            Contact? foundContactName = FindByName(newContact.Name).FirstOrDefault();
            if (foundContactName != null)
            {
                return "Taka nazwa kontaktu juz istnieje";
            }
            return string.Empty;

        }
    }
}
