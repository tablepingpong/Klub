﻿namespace MotoApp.repozytoris;

using Microsoft.EntityFrameworkCore;
using MotoApp.Entities;
using MotoApp.Entitis;
using System.Collections.Generic;

public class SqlRepository<T> : IRepository<T> where T : class, IEntities, new()
{
    private readonly DbSet<T> _dbSet;

    private readonly DbContext _dbContext;

    public SqlRepository(DbContext dbContext)
    {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T item)
    {
        _dbSet.Add(item);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public virtual void Save()
    {
        _dbContext.SaveChanges();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

}


