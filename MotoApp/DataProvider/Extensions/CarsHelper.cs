using System.Reflection.Metadata.Ecma335;

namespace MotoApp.DataProvider.Extentions;

public static class CarsHelper
{
    public static IEnumerable<Car> ByColor(this IEnumerable<Car> query, string color)
    {
        return query.Where(X => X.Color == color);
    }
}
