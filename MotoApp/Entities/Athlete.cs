using MotoApp.Entities;

namespace MotoApp.Entitis;

public class Athlete : EntitiesBase
{
    public string FirstName { get; set; }

    public string Birthyear { get; set; }

    public string Pesel { get; set; }

    public string Phonenumber { get; set; }

    public Category Category { get; set; }

    public override string ToString() => $"Id: {Id}\n" +
        $"FirstName: {FirstName}\n" +
        $"Birthyear: {Birthyear}\n" +
        $"Pesel: {Pesel}\n" +
        $"Phonenumber: {Phonenumber}\n" +
        $"Category: {Category}\n";
}
public enum Category
{
        Mlodzik,
        Kadet,
        Junior,
        Trener
}



