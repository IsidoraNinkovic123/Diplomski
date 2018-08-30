using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class MenadzerProvider : IMenadzerProvider
    {
        private Entities db = new Entities();

        public void Insert(Menadzer entity)
        {
            using (var db = new Entities())
            {
                db.Menadzers.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Menadzer entity)
        {
            using (var db = new Entities())
            {
                Menadzer toChange = db.Menadzers.Where(x => x.MBR == entity.MBR).Include(x => x.Zaposleni).FirstOrDefault();
                toChange.SLUZ_TEL = entity.SLUZ_TEL;
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
                Menadzer menadzer = db.Menadzers.Where(m => m.MBR.Equals(id)).Include(x => x.Hipermarkets).Include(x => x.Dobavljac_robe).FirstOrDefault();
                menadzer.Hipermarkets.Clear();
                menadzer.Dobavljac_robe.Clear();
                db.Entry(menadzer).State = System.Data.Entity.EntityState.Modified;

                db.Entry(menadzer).State = System.Data.Entity.EntityState.Deleted;

                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(menadzer.MBR)).Include(x => x.Zaposleni1).Include(x => x.Zaposleni2).FirstOrDefault();
                zap.Zaposleni_MBR = null;
                zap.Zaposleni1 = null;
                zap.Zaposleni2 = null;
                db.Entry(zap).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Menadzer GetById(int id)
        {
            Menadzer menadzer = db.Menadzers.Where(m => m.MBR.Equals(id)).Include(x => x.Zaposleni).Include(x => x.Hipermarkets).Include(x => x.Dobavljac_robe).FirstOrDefault();
            return menadzer;
        }

        public IQueryable<Menadzer> GetAll()
        {
            return db.Menadzers.Include(x => x.Zaposleni).Include(x => x.Hipermarkets).Include(x => x.Dobavljac_robe);
        }
    }
}
