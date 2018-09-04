﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DontWaste.Api.Core.Contracts
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(string id);

        T Update(T entity);

        IEnumerable<T> Get();

        T Get(string id);
    }
}