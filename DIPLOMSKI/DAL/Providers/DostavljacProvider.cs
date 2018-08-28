using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class DostavljacProvider : IDostavljacProvider
    {
        public void Insert(Dostavljac entity)
        {
            using (var db = new Entities())
            {
                db.Dostavljacs.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Dostavljac entity)
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
                Dostavljac dostavljac = db.Dostavljacs.Where(d => d.MBR.Equals(id)).FirstOrDefault();
                db.Entry(dostavljac).State = System.Data.Entity.EntityState.Deleted;

                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(dostavljac.MBR)).FirstOrDefault();
                zap.Zaposleni_MBR = null;
                zap.Zaposleni1 = null;
                zap.Zaposleni2 = null;
                db.Entry(zap).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Dostavljac GetById(int id)
        {
            using (var db = new Entities())
            {
                Dostavljac dostavljac = db.Dostavljacs.Where(d => d.MBR.Equals(id)).Include(x => x.Zaposleni).Include(x => x.Dostavas).FirstOrDefault();

                return dostavljac;
            }
        }

        public IQueryable<Dostavljac> GetAll()
        {
            Entities db = new Entities();
            return db.Dostavljacs.Include(x => x.Zaposleni);
        }
    }
}
