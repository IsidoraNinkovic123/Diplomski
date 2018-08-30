using Common.Database;
using System.Collections.Generic;
using System.Linq;

namespace Common.Interfaces.Managers
{
    public interface IJeloManager
    {
        void Insert(Jelo entity);
        bool Update(Jelo entity);
        bool Delete(string id);
        Jelo GetById(string id);
        IQueryable<Jelo> GetAll(int pageIndex, int pageSize);
        IQueryable<Jelo> GetByType(int pageIndex, int pageSize, int type);
        int Count();
        int CountForType(int type);
        bool AddSastojak(int sastojakId, string jeloId);
        bool DeleteSastojak(int sastojakId, string jeloId);
    }
}
