namespace domain.Validations;

public class DomainExceptionValidation(string errorMessage) : Exception(errorMessage)
{
    public static void When(bool condition, string errorMessage)
    {
        if(condition) throw new DomainExceptionValidation(errorMessage);
    }
}