using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class DostavljacProvider : IDostavljacProvider
    {
        private Entities db = new Entities();

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
                Dostavljac toChange = db.Dostavljacs.Where(x => x.MBR == entity.MBR).Include(x => x.Zaposleni).FirstOrDefault();
                toChange.VDOZVOLA = entity.VDOZVOLA;
                toChange.Zaposleni.DAT = entity.Zaposleni.DAT;
                toChange.Zaposleni.IME = entity.Zaposleni.IME;
                toChange.Zaposleni.PLT = entity.Zaposleni.PLT;
                toChange.Zaposleni.PRZ = entity.Zaposleni.PRZ;
                toChange.Zaposleni.TEL = entity.Zaposleni.TEL;
                toChange.Zaposleni.Zaposleni_MBR = entity.Zaposleni.Zaposleni_MBR;

                db.Entry(toChange).State = System.Data.Entity.EntityState.Modified;
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
            Dostavljac dostavljac = db.Dostavljacs.Where(d => d.MBR.Equals(id)).Include(x => x.Zaposleni).FirstOrDefault();
            return dostavljac;
        }

        public IQueryable<Dostavljac> GetAll()
        {
            return db.Dostavljacs.Include(x => x.Zaposleni);
        }
    }
}
