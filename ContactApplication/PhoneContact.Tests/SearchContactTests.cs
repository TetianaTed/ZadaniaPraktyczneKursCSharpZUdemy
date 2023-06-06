using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZadaniaPraktyczneKursCSharpZUdemy;

namespace PhoneContact.Tests
{
    [Collection("Sequential")]
    public class SearchContactTests : IDisposable
    {
        public void Dispose()
        {
            ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Clear();
        }
   
        //SearchContactTests
        [Fact]
        public void Search_Contact_by_Name()
        {
            //Arrange
            string arrangeNameToSearch = "Tom";

            //and: save three contacts to database
            Contact arrangeContact = new Contact("Ala", "105106");
            Contact arrangeContact2 = new Contact(arrangeNameToSearch, "7512");
            Contact arrangeContact3 = new Contact("Michal", "571236");

            foreach (var item in new List<Contact> { arrangeContact, arrangeContact2, arrangeContact3 })
            {
                OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(item);
                Assert.True(operationResult.IsSuccess());
            }

            //Act            
            IList<Contact> foundContacts = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindByName(arrangeNameToSearch);

            //Assert
            int actualContactCounter = foundContacts.Count();
            Assert.Equal(1, actualContactCounter);

            Assert.Equal("7512", foundContacts.FirstOrDefault()?.PhoneNumber);

            //dodac test Theory
            //+ find byNumber
            //+ jak baza jest pusta (co bedzie z wyszukiwaniem) 
            //+ wyjatki, jesli sa

        }
    }
}
