using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class MenadzerProvider : IMenadzerProvider
    {
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
            using (var db = new Entities())
            {
                Menadzer menadzer = db.Menadzers.Where(m => m.MBR.Equals(id)).Include(x => x.Zaposleni).Include(x => x.Hipermarkets).Include(x => x.Dobavljac_robe).FirstOrDefault();

                return menadzer;
            }
        }

        public IQueryable<Menadzer> GetAll()
        {
            Entities db = new Entities();
            return db.Menadzers.Include(x => x.Zaposleni).Include(x => x.Hipermarkets).Include(x => x.Dobavljac_robe);
        }
    }
}
