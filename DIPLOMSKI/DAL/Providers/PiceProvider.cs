using Common.Database;
using System.Linq;
using System.Data.Entity;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class PiceProvider : IPiceProvider
    {
        public void Insert(Pice entity)
        {
            using (var db = new Entities())
            {
                db.Pices.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Pice entity)
        {
            using (var db = new Entities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                Stavka_menija stavka = db.Stavka_menija.Where(s => s.ID.Equals(entity.ID)).FirstOrDefault();
                db.Entry(stavka).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new Entities())
            {
                Pice pice = db.Pices.Where(p => p.ID.Equals(id)).FirstOrDefault();
                db.Entry(pice).State = System.Data.Entity.EntityState.Deleted;

                Stavka_menija stavka = db.Stavka_menija.Where(s => s.ID.Equals(id)).FirstOrDefault();
                stavka.Nalazi_se.Clear();
                db.Entry(stavka).State = System.Data.Entity.EntityState.Modified;
                db.Entry(stavka).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Pice GetById(string id)
        {
            using (var db = new Entities())
            {
                Pice pice = db.Pices.Where(p => p.ID.Equals(id)).Include(x => x.Stavka_menija).FirstOrDefault();

                return pice;
            }
        }

        public IQueryable<Pice> GetAll()
        {
            Entities db = new Entities();
            return db.Pices.Include(x => x.Stavka_menija);
        }
    }
}
