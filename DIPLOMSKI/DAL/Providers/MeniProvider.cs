using Common.Database;
using System.Linq;
using System.Data.Entity;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class MeniProvider : IMeniProvider
    {
        public void Insert(Meni entity)
        {
            using (var db = new Entities())
            {
                db.Menis.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Meni entity)
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
                Meni men = db.Menis.Where(m => m.ID.Equals(id)).FirstOrDefault();

                db.Entry(men).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Meni GetById(int? id)
        {
            using (var db = new Entities())
            {
                Meni men = db.Menis.Where(m => m.ID == id).Include(x => x.Stavka_menija).FirstOrDefault();

                return men;
            }
        }

        public IQueryable<Meni> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Menis.Include(x => x.Stavka_menija);
            }
        }

    }
}
