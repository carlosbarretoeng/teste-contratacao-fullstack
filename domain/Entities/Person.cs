using domain.Validations;

namespace domain.Entities;

public class Person
{
    public string? TaxNumber { get; private set; }
    public string Name { get; private set; }
    
    public ICollection<Vehicle>? Vehicles { get; set; }
    
    public Person(string taxNumber, string name)
    {
        // TODO: Implementar validação de CPF
        DomainExceptionValidation.When(string.IsNullOrEmpty(taxNumber), nameof(taxNumber));
        
        ValidateDomain(name);
        
        TaxNumber = taxNumber;
        Name = name;
    }
    
    public Person(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    private static void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be empty.");
    }

    public void Update(string name)
    {
        ValidateDomain(name);
        Name = name;
    }
}