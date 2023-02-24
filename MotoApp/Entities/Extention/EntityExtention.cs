using System.Text.Json;

namespace MotoApp.Entities.Extention;

public static class EntityExtention
{
    public static T? Copy<T>(this T itemToCopy) where T : IEntities
    {
        var json = JsonSerializer.Serialize(itemToCopy);
        return JsonSerializer.Deserialize<T>(json);
    }
}