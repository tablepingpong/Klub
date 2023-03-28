using MotoApp.Entities;
using Newtonsoft.Json;
using System.IO;
using System.Text.Json;

namespace MotoApp.Repozytory
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
            string objectsSerialized = JsonConvert.SerializeObject(_items);
            var fileJson = File.AppendText(path);
            using(fileJson)
            {
                fileJson.Write(objectsSerialized);
                fileJson.Dispose();
            }

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
