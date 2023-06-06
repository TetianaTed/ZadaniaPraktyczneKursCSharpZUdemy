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
    public class UpdateContactTests : IDisposable
    {
        public void Dispose()
        {
            ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Clear();
        }

        //UpdateContactTests
        [Fact]
        public void Should_Update_Contact_By_Name()
        {
            //Arrange
            Contact arrangeContact = new Contact("Ben", "0125689");
            Contact arrangeContact2 = new Contact("Did", "7856");

            OperationResult arrangeOperationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);
            OperationResult arrangeOperationResult2 = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact2);

            Assert.True(arrangeOperationResult.IsSuccess());
            Assert.True(arrangeOperationResult2.IsSuccess());

            int arrangeContactInDatabaseCounter = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Count;
            Assert.Equal(2, arrangeContactInDatabaseCounter);

            Contact arrangeContact3 = new Contact("Ben", "5555555");

            //Act 
            OperationResult operationResultUpdate = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.UpdateContactByName(arrangeContact3);

            //Assert
            Assert.True(operationResultUpdate.IsSuccess());
            string? actualPhoneNumber = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll()
                                        .SingleOrDefault(contact => contact.Name.Equals("Ben"))?
                                        .PhoneNumber;
            Assert.Equal("5555555", actualPhoneNumber);
        }
        
        //Zadanie domowe: dorobic testy na walidacje (jest podobny do add.)
    }
}
