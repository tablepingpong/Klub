
using MotoApp.Entities;
using System.Text;

public class Car :EntityBase
{
    public string Name { get; set; }

    public string Color { get; set; }

    public decimal StandardCost { get; set; }

    public decimal ListPrice { get; set; }

    public string Type { get; set; }

    public int? NameLength { get; set; }

    public decimal? TotalSales { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new(8);
        sb.AppendLine($"{Name} Id: {Id}");
        sb.AppendLine($"Color: {Color} Type: {(Type ?? "n/a")}");
        sb.AppendLine($" Cost: {StandardCost:c} Price: {ListPrice:c}");
        if (NameLength.HasValue) 
        {
            sb.AppendLine($" Name Length: {NameLength}");
        }
        if (TotalSales.HasValue)
        {
            sb.AppendLine($"Total Sales: {TotalSales:c}");
            
        }
        return sb.ToString();
    }
}

