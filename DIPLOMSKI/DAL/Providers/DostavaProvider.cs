using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class DostavaProvider : IDostavaProvider
    {
        private Entities db = new Entities();

        public void Insert(Dostava entity)
        {
            using (var db = new Entities())
            {
                db.Dostavas.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Dostava entity)
        {
            using (var db = new Entities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                Porudzbina por = db.Porudzbinas.Where(p => p.ID.Equals(entity.ID)).FirstOrDefault();
                db.Entry(por).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new Entities())
            {
                Dostava dostava = db.Dostavas.Where(d => d.ID.Equals(id)).FirstOrDefault();
                db.Entry(dostava).State = System.Data.Entity.EntityState.Deleted;

                Porudzbina por = db.Porudzbinas.Where(p => p.ID.Equals(id)).FirstOrDefault();
                db.Entry(por).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Dostava GetById(string id)
        {
            Dostava dostava = db.Dostavas.Where(d => d.ID.Equals(id)).Include(x => x.Porudzbina).FirstOrDefault();
            return dostava;
        }

        public IQueryable<Dostava> GetAll()
        {
            return db.Dostavas.Include(x => x.Porudzbina);
        }
    }
}
