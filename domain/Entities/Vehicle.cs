using domain.Validations;

namespace domain.Entities;

public class Vehicle
{
    public string? Plate { get; private set; }
    public string Model { get; private set; }
    public string PersonId { get; private set; }
    public Person? Person { get; set; }

    public Vehicle(string plate, string model, string personId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(plate), "Plate cannot be empty.");
        ValidateDomain(model, personId);
        
        Plate = plate;
        Model = model;
        PersonId = personId;
    }
    
    public Vehicle(string model, string personId)
    {
        ValidateDomain(model, personId);
        Model = model;
        PersonId = personId;
    }

    private static void ValidateDomain(string model, string personId)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(model), "Model cannot be empty.");
        DomainExceptionValidation.When(string.IsNullOrEmpty(personId), "PersonId cannot be empty.");
    }

    public void Update(string model, string personId)
    {
        ValidateDomain(model, personId);
        
        Model = model;
        PersonId = personId;
    }
}