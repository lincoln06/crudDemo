using FluentValidation.Results;

public class Smartphone : IItem
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public Smartphone(string manufacturer, string model)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
    public Smartphone()
    {

    }
    public List<ValidationFailure> Validate()
    {
        throw new NotImplementedException();
    }
}