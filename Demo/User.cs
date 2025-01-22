namespace Demo
{
    
    public class User
    {
        public string Name { get; set; }
        public bool IsConnected { get; set; }

        public User(string name)
        {
            Name = name;
            IsConnected = false;
        }

        public void Connect()
        {
            IsConnected = true;
            Console.WriteLine("User is connected"); // En général on test pas les écritures dans la console
        }

        public void ChangeNameIfConnected(string newName)
        {
            if (!IsConnected)
                throw new NotConnectedException("User is not connected");

            Name = newName;
        }

        public bool IsEvenValue(int value)
        {
            return value % 2 == 0;
        }

        public string ReturnGreetingMessage(string message)

        {
            
            return "Greeting: to  " + message;
        }
        
        
    }

    public class NotConnectedException : Exception
    {
        public NotConnectedException(string? message) : base(message)
        {
        }
    }
}