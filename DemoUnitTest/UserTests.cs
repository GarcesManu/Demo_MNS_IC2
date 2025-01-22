
using Demo;
namespace DemoUnitTest;

[TestClass]
public class UserTests
{
    [TestMethod]
    public void Connect_WithNewUnconnectedUser_IsConnectedIsTrue()
    {
        // ARRANGE (Contexte)
        User user = new User("Bonjour");
            user.IsConnected = false;
        // Act (Action / méthode qu'on veut tester
        user.Connect();
        // Assert (Vérification de bon fonctionnement)
        Assert.IsTrue(user.IsConnected);
    }
    
    [TestMethod]
    public void Connect_WithAlreadyUnconnectedUser_IsConnectedIsTrue()
    
    {
        // ARRANGE (Contexte)
        User user = new User("Bonjour");
        user.IsConnected = true;
        // Act (Action / méthode qu'on veut tester
        user.Connect();
        // Assert (Vérification de bon fonctionnement)
        Assert.IsTrue(user.IsConnected);
    }
    [TestMethod]
    
    public void ChangeNameIfConnected_WithNotConnectedUser_ThrowsNotConnectedException()
    {
        // ARRANGE (Contexte)
        User user = new User("Bonjour");
        user.IsConnected = false;
        // Act (Action / méthode qu'on veut tester
        // &
        // Assert (Vérification de bon fonctionnement)
        Assert.ThrowsException<NotConnectedException>(() => user.ChangeNameIfConnected("Hello"));
    }

    [TestMethod]

    public void ChangeNameIfConnected_WithConnectedUser_NameHasNewValue()

    {
        
        //Arrange
        User user = new User("Bonjour");
        user.IsConnected = true;
        //act
        user.ChangeNameIfConnected("NewValue");
        //assert
        Assert.AreEqual("NewValue", user.Name);
        
    }

    [TestMethod]

    public void IsEvenValue_WithEvenNumber_ReturnsTrue()

    {
        
        User user = new User("nom");

        var value = 20;
        
        var result = user.IsEvenValue(value);   
        Assert.IsTrue(result);
    }
    
    [TestMethod]

    public void IsEvenValue_WithNotEvenNumber_ReturnsTrue()

    {
        
        User user = new User("nom");

        var value = 31;
        
        var result = user.IsEvenValue(value);   
        Assert.IsFalse(result);
    }
    
    [TestMethod]

    public void ReturnGreetingMessage_WithMessage_ReturnStringGreetingAndMessage()

    {
        
        User user = new User("nom");
        var message = "My message";
        
        var result = user.ReturnGreetingMessage(message);   

        Assert.IsTrue(result.Contains("Greeting"));
        Assert.IsTrue(result.Contains(message));
    }
    
}