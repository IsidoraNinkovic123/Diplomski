﻿using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface IJeloProvider
    {
        void Insert(Jelo entity);
        void Update(Jelo entity);
        void Delete(string id);
        Jelo GetById(string id);
        IQueryable<Jelo> GetAll();
    }
}
