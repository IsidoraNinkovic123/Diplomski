using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class KonobarProvider : IKonobarProvider
    {
        private Entities db = new Entities();

        public void Insert(Konobar entity)
        {
            using (var db = new Entities())
            {
                db.Konobars.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Konobar entity)
        {
            using (var db = new Entities())
            {
                Konobar toChange = db.Konobars.Where(x => x.MBR == entity.MBR).Include(x => x.Zaposleni).FirstOrDefault();
                toChange.KNJIZ = entity.KNJIZ;
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
                Konobar kon = db.Konobars.Where(k => k.MBR.Equals(id)).FirstOrDefault();
                db.Entry(kon).State = System.Data.Entity.EntityState.Deleted;

                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(kon.MBR)).FirstOrDefault();
                zap.Zaposleni_MBR = null;
                zap.Zaposleni1 = null;
                zap.Zaposleni2 = null;
                db.Entry(zap).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Konobar GetById(int id)
        {
            Konobar kon = db.Konobars.Where(k => k.MBR.Equals(id)).Include(x => x.Zaposleni).FirstOrDefault();
            return kon;
        }

        public IQueryable<Konobar> GetAll()
        {
            return db.Konobars.Include(x => x.Zaposleni);
        }
    }
}
