using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class HipermarketProvider : IHipermarketProvider
    {
        public void Insert(Hipermarket entity)
        {
            using (var db = new Entities())
            {
                db.Hipermarkets.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Hipermarket entity)
        {
            using (var db = new Entities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Entities())
            {
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == id).FirstOrDefault();

                db.Entry(hip).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Hipermarket GetById(int id)
        {
            using (var db = new Entities())
            {
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == id).Include(x => x.Menadzers).FirstOrDefault();

                return hip;
            }
        }

        public IQueryable<Hipermarket> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Hipermarkets.Include(x => x.Menadzers);
            }
        }
    }
}
