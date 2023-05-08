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
        public string Name {get; set;}  

        public string PhoneNumber { get; set;}

        public Contact(string name, string phoneNumber)
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"Contact (Name = {this.Name}; PhoneNumber = {this.PhoneNumber};)";
        }

    }
}
