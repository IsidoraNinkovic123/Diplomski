using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class JeloProvider : IJeloProvider
    {
        public void Insert(Jelo entity)
        {
            using (var db = new Entities())
            {
                db.Jeloes.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Jelo entity)
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
                Jelo jelo = db.Jeloes.Where(j => j.ID.Equals(id)).FirstOrDefault();

                db.Entry(jelo).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Jelo GetById(string id)
        {
            using (var db = new Entities())
            {
                Jelo jelo = db.Jeloes.Where(j => j.ID.Equals(id)).Include(x => x.Stavka_menija).FirstOrDefault();

                return jelo;
            }
        }

        public IQueryable<Jelo> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Jeloes.Include(x => x.Stavka_menija).Include(x => x.Kuvars);
            }
        }
    }
}
