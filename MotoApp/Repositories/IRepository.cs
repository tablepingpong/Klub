﻿
namespace MotoApp.Repozytory;
using MotoApp.Entities;
public interface IRepository<T> : IRead<T>, Iwrite<T>
        where T : class, IEntities
{ 
}

