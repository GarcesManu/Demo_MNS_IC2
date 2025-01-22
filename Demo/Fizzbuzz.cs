namespace Demo
{
    public class FizzBuzz
    {
        public string GetOutput(int value)
        {
            if (value < 0)
                throw new ArgumentException("Value cannot be negative");

            if (value % 5 == 0 && value % 3 == 0)
                return "FizzBuzz";

            else if (value % 3 == 0)
                return "Fizz";

            else if (value % 5 == 0)
                return "Buzz";

            return value.ToString();
        }
    }
}