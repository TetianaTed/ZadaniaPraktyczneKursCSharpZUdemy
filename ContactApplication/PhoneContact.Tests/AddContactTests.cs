using Xunit;
using ZadaniaPraktyczneKursCSharpZUdemy;

namespace PhoneContact.Tests

{
    [Collection("Sequential")]
    public class AddContactTests :IDisposable
    {
        public void Dispose()
        {
            ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Clear();
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Should_Add_Contact_When_Database_Is_Empty()
        {
            //Arrange
            Contact arrangeContact = new Contact("Tet","1234");

            //Act
            OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);

            //Assert
            Assert.True(operationResult.IsSuccess());

            int contactCounter = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Count;
            Assert.Equal(1, contactCounter);

        }

        //zadanie domowe: dopisac testy na przypadki walidacyjne

        [Fact]
        public void Should_Add_2_Contacts()
        {
            //Arrange
            Contact arrangeContact = new Contact("Tetiana", "1234");
            Contact arrangeContact2 = new Contact("Michal", "567894");

            //Act
            OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);
            OperationResult operationResult2 = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact2);

            //Assert
            Assert.True(operationResult.IsSuccess());
            Assert.True(operationResult2.IsSuccess());

            int contactCounter = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.FindAll().Count;
            Assert.Equal(2, contactCounter);

        }

        [Fact]
        public void Should_Throw_Error_When_Add_Contact_With_Existing_Name()
        {
            //Arrange
            Contact arrangeContact = new Contact("Tet", "1234");
            OperationResult expectedAddedContact = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);
            Assert.True(expectedAddedContact.IsSuccess());

            Contact arrangeContactWithExistingName = new Contact(arrangeContact.Name, "89634"); 

            //Act (try save contact with existing name)
            OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContactWithExistingName);

            //Assert (operation should failure)
            Assert.True(operationResult.IsError());
            Assert.False(operationResult.IsSuccess());
            Assert.Contains("Taka nazwa kontaktu juz istnieje", operationResult.ErrorMessage);
        }

        [Fact]
        public void Should_Throw_Error_When_Add_Contact_With_Existed_Number()
        {
            //Arrange
            Contact arrangeContact = new Contact("Tet", "1234");
            OperationResult expectedAddedContact = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);
            Assert.True(expectedAddedContact.IsSuccess());

            Contact arrangeContactWithExistingNumber = new Contact("Bob", arrangeContact.PhoneNumber); 

            //Act (try save contact with existing number)
            OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContactWithExistingNumber);

            //Assert (operation should failure)
            Assert.True(operationResult.IsError());           
            Assert.Contains("Taki numer telefonu juz istnieje", operationResult.ErrorMessage);
        }

        [Fact]
        public void Should_Throw_Error_When_Add_Contact_With_Existed_Contact()
        {
            //Arrange
            Contact arrangeContact = new Contact("Tet", "1234");
            OperationResult expectedAddedContact = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeContact);
            Assert.True(expectedAddedContact.IsSuccess());

            Contact arrangeExistingContact = new Contact(arrangeContact.Name, arrangeContact.PhoneNumber);

            //Act (try save existing contact)
            OperationResult operationResult = ZadaniaPraktyczneKursCSharpZUdemy.PhoneContact.Add(arrangeExistingContact);

            //Assert (operation should failure)
            Assert.True(operationResult.IsError());
            Assert.Contains("Taki numer telefonu juz istnieje", operationResult.ErrorMessage);
        }
    }
}