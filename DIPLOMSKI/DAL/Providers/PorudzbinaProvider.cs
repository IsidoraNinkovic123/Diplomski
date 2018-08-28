using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class PorudzbinaProvider : IPorudzbinaProvider
    {
        public void Insert(Porudzbina entity)
        {
            using (var db = new Entities())
            {
                db.Porudzbinas.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Porudzbina entity)
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
                Porudzbina porudzbina = db.Porudzbinas.Where(p => p.ID.Equals(id)).FirstOrDefault();

                db.Entry(porudzbina).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Porudzbina GetById(string id)
        {
            using (var db = new Entities())
            {
                Porudzbina porudzbina = db.Porudzbinas.Where(p => p.ID.Equals(id)).Include(x => x.Nalazi_se).FirstOrDefault();

                return porudzbina;
            }
        }

        public IQueryable<Porudzbina> GetAll()
        {
            Entities db = new Entities();
            return db.Porudzbinas.Include(x => x.Nalazi_se);
        }
    }
}
