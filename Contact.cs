using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ZadaniaPraktyczneKursCSharpZUdemy
{
    internal class Contact
    {
        //statyczne pola dajemy na poczatku
        private static string language = "pl";

        //zasieg - scope (slowko public/private) dajemy na poczatku
        private static List<Contact> contacts = new List<Contact>();

        private string _name; // field
        public string Name   // property
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _phoneNumber;  // Backing store

        public string PhoneNumber
        {

            get { return _phoneNumber; }
            set { _phoneNumber = value; }

            //dodac weryfikacje
            /*
            get => _numerTelefonu;
                   
            set
            {
                if ((value > 0) && (value < 13))
                {
                    _numerTelefonu = value;
                }
            }
            */

        }

        //Konstruktor piszemy za wlasciwosciami
        //metoda ktora tworzy obiekt
        //nazwa jak klasa, zacieg(scope) moze byc private lub public, internal, protected, virtual i inne

        public Contact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;

        }

        //wypisuje wszytkie informacje, jakie zdefinuje, o stanie obiektu
        // override ma nadpisac
        public override string ToString()
        {
            //return "Contact (Name = " + this.Name + "; PhoneNumber = " + this.PhoneNumber + ")";
            return $"Contact (Name = {this.Name}; PhoneNumber = {this.PhoneNumber}; Language = {language})"; //dla statycznych nie ma this
        }

        //static ma wplyw na wszystkie obiekty danego typu, (w tym przypadku Contact) bedacych w pamieci RAM (podczas dzialania programu)
        public static Contact Test(string name)
        {
            //tu nie ma this
            Contact.language = "bla bla";
            return new Contact(name, "98561234");
        }

        public void Add(Contact newContact)
        {
            contacts.Add(newContact);
        }
    }
}
