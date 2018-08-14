using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class SastojakProvider : ISastojakProvider
    {
        public void Insert(Sastojak entity)
        {
            using (var db = new Entities())
            {
                db.Sastojaks.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Sastojak entity)
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
                Sastojak sastojak = db.Sastojaks.Where(s => s.ID == id).FirstOrDefault();

                db.Entry(sastojak).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Sastojak GetById(int id)
        {
            using (var db = new Entities())
            {
                Sastojak sastojak = db.Sastojaks.Where(s => s.ID == id).FirstOrDefault();

                return sastojak;
            }
        }

        public IQueryable<Sastojak> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Sastojaks;
            }
        }
    }
}
