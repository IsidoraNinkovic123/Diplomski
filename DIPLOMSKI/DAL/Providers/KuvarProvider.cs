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

                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(entity.MBR)).FirstOrDefault();
                db.Entry(zap).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Entities())
            {
                Kuvar kuvar = db.Kuvars.Where(k => k.MBR.Equals(id)).Include(x => x.Jeloes).FirstOrDefault();
                kuvar.Jeloes.Clear();
                db.Entry(kuvar).State = System.Data.Entity.EntityState.Modified;

                db.Entry(kuvar).State = System.Data.Entity.EntityState.Deleted;

                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(kuvar.MBR)).FirstOrDefault();
                zap.Zaposleni_MBR = null;
                zap.Zaposleni1 = null;
                zap.Zaposleni2 = null;
                db.Entry(zap).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Kuvar GetById(int id)
        {
            using (var db = new Entities())
            {
                Kuvar kuvar = db.Kuvars.Where(k => k.MBR.Equals(id)).Include(x => x.Zaposleni).Include(x => x.Jeloes).FirstOrDefault();

                return kuvar;
            }
        }

        public IQueryable<Kuvar> GetAll()
        {
            Entities db = new Entities();
            return db.Kuvars.Include(x => x.Zaposleni).Include(x => x.Jeloes);
        }

        public void AddJelo(string jeloId, int kuvId)
        {
            using (var db = new Entities())
            {
                Kuvar kuv = db.Kuvars.Where(k => k.MBR == kuvId).Include(x => x.Jeloes).FirstOrDefault();
                Jelo jel = db.Jeloes.Where(j => j.ID == jeloId).FirstOrDefault();

                kuv.Jeloes.Add(jel);

                db.Entry(kuv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteJelo(string jeloId, int kuvId)
        {
            using (var db = new Entities())
            {
                Kuvar kuv = db.Kuvars.Where(k => k.MBR == kuvId).Include(x => x.Jeloes).FirstOrDefault();
                Jelo jel = db.Jeloes.Where(j => j.ID == jeloId).FirstOrDefault();

                kuv.Jeloes.Remove(jel);

                db.Entry(kuv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
