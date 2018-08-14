using Common.Database;
using System.Linq;
using System.Data.Entity;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class RestoranProvider : IRestoranProvider
    {
        public void Insert(Restoran entity)
        {
            using (var db = new Entities())
            {
                db.Restorans.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Restoran entity)
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
                Restoran res = db.Restorans.Where(r => r.ID.Equals(id)).FirstOrDefault();

                db.Entry(res).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Restoran GetById(int? id)
        {
            using (var db = new Entities())
            {
                Restoran res = db.Restorans.Where(r => r.ID == id).Include(x => x.Menis).Include(x => x.Zaposlenis).FirstOrDefault();

                return res;
            }
        }

        public IQueryable<Restoran> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Restorans.Include(x => x.Menis).Include(x => x.Zaposlenis);
            }
        }
    }
}
