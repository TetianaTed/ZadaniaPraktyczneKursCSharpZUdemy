using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZadaniaPraktyczneKursCSharpZUdemy;

namespace PhoneContact.Tests
{
    public class Testing
    {
        [Fact]
        public static void test()
        {
            IList<int> contacts = new List<int>();
            contacts.Add(7);
            contacts.Add(3);
            contacts.Add(1);
            contacts.Add(4);
            contacts.Add(9);
            contacts.Add(2);

            int lowerThan4 = (from contact in contacts
                              where contact < 4
                              select contact).Count();
            Assert.Equal(3, lowerThan4);

            int lowerThan5 = contacts.Where(contact => contact < 5).Count();

            Assert.Equal(4, lowerThan5);
        }

    }
}
