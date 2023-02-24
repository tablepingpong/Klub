﻿using MotoApp.Entities;
namespace MotoApp.repozytoris;

    public interface Iwrite<in T> where T : class, IEntities
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        
    }

