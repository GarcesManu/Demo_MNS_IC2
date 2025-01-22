namespace Demo;

public class Calculator
{
    public int Add(int numberOne, int numberTwo)
    {
        if (numberOne < 0)
            throw new ArgumentException("numberOne cannot be negative");
        if (numberTwo > 1000)
            throw new ArgumentException("numberTwo cannot be greater than 1000");
        
        return numberOne + numberTwo;
    }

    public int Substract(int numberOne, int numberTwo)
    {
        return numberOne - numberTwo;
    }

    public int Multiply(int numberOne, int numberTwo)
    {
        return numberOne * numberTwo;
    }

    // ça devrait retourner un float, mais faites vos tests
    // avec des nombres qui retourne un résultat sans chiffre après la virgule
    public int Divide(int numberOne, int numberTwo)
    {
        if (numberTwo == 0)
            throw new ArgumentException("numberTwo cannot be equal to zero");

        return numberOne / numberTwo;
    }
}