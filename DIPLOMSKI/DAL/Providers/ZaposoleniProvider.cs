using Common.Database;
using Common.Interfaces.Providers;
using System.Linq;

namespace DAL.Providers
{
    public class ZaposoleniProvider : IZaposleniProvider
    {
        public void Insert(Zaposleni entity)
        {
            using (var db = new Entities())
            {
                db.Zaposlenis.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Zaposleni entity)
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
                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(id)).FirstOrDefault();

                db.Entry(zap).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Zaposleni GetById(string id)
        {
            using (var db = new Entities())
            {
                Zaposleni zap = db.Zaposlenis.Where(z => z.MBR.Equals(id)).FirstOrDefault();

                return zap;
            }
        }

        public IQueryable<Zaposleni> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Zaposlenis;
            }
        }
    }
}
