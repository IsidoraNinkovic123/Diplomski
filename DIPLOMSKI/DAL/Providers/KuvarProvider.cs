using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class KuvarProvider : IKuvarProvider
    {
        public void Insert(Kuvar entity)
        {
            using (var db = new Entities())
            {
                db.Kuvars.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Kuvar entity)
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
                Kuvar kuvar = db.Kuvars.Where(k => k.MBR.Equals(id)).FirstOrDefault();

                db.Entry(kuvar).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Kuvar GetById(string id)
        {
            using (var db = new Entities())
            {
                Kuvar kuvar = db.Kuvars.Where(k => k.MBR.Equals(id)).Include(x => x.Zaposleni).FirstOrDefault();

                return kuvar;
            }
        }

        public IQueryable<Kuvar> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Kuvars.Include(x => x.Zaposleni);
            }
        }

        public void AddJelo(string jeloId, string kuvId)
        {
            using (var db = new Entities())
            {
                Kuvar kuv = db.Kuvars.Where(k => k.MBR == kuvId).FirstOrDefault();
                Jelo jel = db.Jeloes.Where(j => j.ID == jeloId).FirstOrDefault();

                kuv.Jeloes.Add(jel);

                db.Entry(kuv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteJelo(string jeloId, string kuvId)
        {
            using (var db = new Entities())
            {
                Kuvar kuv = db.Kuvars.Where(k => k.MBR == kuvId).FirstOrDefault();
                Jelo jel = db.Jeloes.Where(j => j.ID == jeloId).FirstOrDefault();

                kuv.Jeloes.Remove(jel);

                db.Entry(kuv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
