using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.repozytoris.Repoextention;

public static class RepositoryExtention
{ 
    public static void AddBatch<T>(this IRepository<T> repositoris, T[] items)
    where T : class, IEntities
    {
        foreach (var item in items)
        {
            repositoris.Add(item);
        }
        repositoris.Save();
    }

    public static void AddBatch<T>(this string zawodnik, T[] items)
    where T : class, IEntities
    {
        
    }
}
