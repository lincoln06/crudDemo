using FluentValidation.Results;

public class Notebook : IItem
{
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public Notebook(string manufacturer, string model)
    {
        Manufacturer = manufacturer;
        Model = model;
    }
    public Notebook()
    {

    }
    public List<ValidationFailure> Validate()
    {
        throw new NotImplementedException();
    }
}