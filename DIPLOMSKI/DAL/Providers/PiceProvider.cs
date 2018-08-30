using Common.Database;
using System.Linq;
using System.Data.Entity;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class PiceProvider : IPiceProvider
    {
        private Entities db = new Entities();

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
                Pice toChange = db.Pices.Where(x => x.ID.Equals(entity.ID)).Include(x => x.Stavka_menija).FirstOrDefault();
                toChange.ALKOHOLNO = entity.ALKOHOLNO;
                toChange.ZAP = entity.ZAP;
                toChange.Stavka_menija.CENA = entity.Stavka_menija.CENA;
                toChange.Stavka_menija.NAZ = entity.Stavka_menija.NAZ;

                db.Entry(toChange).State = System.Data.Entity.EntityState.Modified;
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
            Pice pice = db.Pices.Where(p => p.ID.Equals(id)).Include(x => x.Stavka_menija).FirstOrDefault();
            return pice;
        }

        public IQueryable<Pice> GetAll()
        {
            return db.Pices.Include(x => x.Stavka_menija);
        }
    }
}
