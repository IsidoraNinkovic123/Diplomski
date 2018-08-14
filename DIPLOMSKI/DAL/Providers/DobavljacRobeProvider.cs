using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class DobavljacRobeProvider : IDobavljacRobeProvider
    {
        public void Insert(Dobavljac_robe entity)
        {
            using (var db = new Entities())
            {
                db.Dobavljac_robe.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Dobavljac_robe entity)
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
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == id).FirstOrDefault();

                db.Entry(dob).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Dobavljac_robe GetById(int id)
        {
            using (var db = new Entities())
            {
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == id).Include(x => x.Menadzers).FirstOrDefault();

                return dob;
            }
        }

        public IQueryable<Dobavljac_robe> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Dobavljac_robe.Include(x => x.Menadzers);
            }
        }
    }
}
