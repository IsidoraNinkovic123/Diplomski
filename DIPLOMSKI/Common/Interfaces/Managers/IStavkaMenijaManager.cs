﻿using Common.Database;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IStavkaMenijaManager
    {
        void Insert(Stavka_menija entity);
        bool Update(Stavka_menija entity);
        bool Delete(string id);
        Stavka_menija GetById(string id);
        IQueryable<Stavka_menija> GetAll(int pageIndex, int pageSize, int meniId);
        int Count(int meniID);
    }
}
