using Common.Database;
using Common.Interfaces.Providers;
using System.Linq;
using System.Data.Entity;

namespace DAL.Providers
{
    public class StavkaMenijaProvider : IStavkaMenijaProvider
    {
        private Entities db = new Entities();

        public void Insert(Stavka_menija entity)
        {
            using (var db = new Entities())
            {
                db.Stavka_menija.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Stavka_menija entity)
        {
            using (var db = new Entities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new Entities())
            {
                Stavka_menija st = db.Stavka_menija.Where(s => s.ID.Equals(id)).FirstOrDefault();

                db.Entry(st).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Stavka_menija GetById(string id)
        {
            Stavka_menija st = db.Stavka_menija.Where(s => s.ID.Equals(id)).Include(x => x.Jelo).Include(x => x.Pice).FirstOrDefault();
            return st;
        }

        public IQueryable<Stavka_menija> GetAll()
        {
            return db.Stavka_menija.Include(x => x.Jelo).Include(x => x.Pice);
        }
    }
}
