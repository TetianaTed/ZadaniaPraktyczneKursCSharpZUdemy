using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaPraktyczneKursCSharpZUdemy
{
    public class PhoneContact
    {
        private static IList<Contact> contacts = new List<Contact>();

        public static OperationResult Add(Contact newContact)
        {
            string validationResult = ValidateCreate(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {              
                return new OperationResult("Dodanie kontaktu nie jest mozliwe. Szczegóły: " + validationResult);
            }

            contacts.Add(newContact);

            return OperationResult.Success();
            
        }

        public static Contact? FindByNumber(string contactNumber)
        {
            return contacts
                .Where(contact => contact.PhoneNumber.Equals(contactNumber, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
        }

        public static IList<Contact> FindAll()
        {
            return contacts;
        }

        public static IList<Contact> FindByName(string inputName)
        {
            return contacts.Where(contact => contact.Name.Contains(inputName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public static OperationResult UpdateContactByName(Contact newContact)
        {
            string validationResult = ValidateUpdateByName(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {
                return new OperationResult("Aktualizacja nie jest mozliwa. Szczegóły: " + validationResult);
            }

            Contact? foundContact = FindByName(newContact.Name).FirstOrDefault();

            if (foundContact == null)
            {
                return new OperationResult($"Nie znaleziono kontaktu z nazwa {newContact.Name}");
            }

            foundContact.PhoneNumber = newContact.PhoneNumber;

            return OperationResult.Success();
        }

        public static OperationResult UpdateContactByNumber(Contact newContact)
        {
            string validationResult = ValidateUpdateByNumber(newContact);

            if (!string.IsNullOrEmpty(validationResult))
            {
                return new OperationResult("Aktualizacja nie jest mozliwa. Szczegóły: " + validationResult);
            }

            Contact? foundContact = FindByNumber(newContact.PhoneNumber);

            if (foundContact == null)
            {
                return new OperationResult($"Nie znaleziono kontaktu z numerem {newContact.PhoneNumber}");
            }

            foundContact.Name = newContact.Name;

            return OperationResult.Success();
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
