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
            IList<Contact> foundContacts = new List<Contact>();

            foreach (var contact in contacts)
            {
                if (!string.IsNullOrWhiteSpace(oldContact.Name) && contact.Name.Equals(oldContact.Name,StringComparison.OrdinalIgnoreCase))
                {
                    foundContacts.Add(contact);
                }
                if (!string.IsNullOrWhiteSpace(oldContact.PhoneNumber) && 
                                              (contact.PhoneNumber.Equals(oldContact.PhoneNumber, StringComparison.OrdinalIgnoreCase) 
                                                && !oldContact.PhoneNumber.Equals("-1")))
                {
                    foundContacts.Add(contact);
                }
            }


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
        }
    }
}
