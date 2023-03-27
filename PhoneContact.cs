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
    }
}
