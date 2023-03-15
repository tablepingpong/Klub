using MotoApp.Entities;
using System.IO;
using System.Text.Json;

namespace MotoApp.repozytoris
{
    public class ListRepository<T> : IRepository<T> where T : class, IEntities, new()
        
    {
        private readonly List<T> _items = new();

        private readonly string path = $"{typeof(T).Name}_save.json";

        public IEnumerable<T>GetAll()
        {
            return _items.ToList();
        }
        
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Save()
        {

            File.Delete(path);
            var objectsSerialized = JsonSerializer.Serialize<IEnumerable<T>>(_items);
            File.WriteAllText(path, objectsSerialized);
            //foreach (var item in _items)
            //{
            //    Console.WriteLine(item);
            //}
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }

        public void Remove(T item) 
        {
            _items.Remove(item);
        }
    }
}
