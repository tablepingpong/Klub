using MotoApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoApp.repozytoris;

    public interface IRead<out T> where T : class, IEntities
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

