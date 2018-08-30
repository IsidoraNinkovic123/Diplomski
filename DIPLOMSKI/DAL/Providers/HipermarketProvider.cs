using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class HipermarketProvider : IHipermarketProvider
    {
        private Entities db = new Entities();

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
                Hipermarket toChange = db.Hipermarkets.Where(x => x.ID == entity.ID).FirstOrDefault();
                toChange.NAZ = entity.NAZ;
                toChange.TEL = entity.TEL;
                toChange.ADR = entity.ADR;

                db.Entry(toChange).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Entities())
            {
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == id).Include(x => x.Menadzers).FirstOrDefault();
                hip.Menadzers.Clear();
                db.Entry(hip).State = System.Data.Entity.EntityState.Modified;

                db.Entry(hip).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Hipermarket GetById(int id)
        {
            Hipermarket hip = db.Hipermarkets.Where(h => h.ID == id).Include(x => x.Menadzers).FirstOrDefault();
            return hip;
        }

        public IQueryable<Hipermarket> GetAll()
        {
            return db.Hipermarkets.Include(x => x.Menadzers);
        }

        public void AddMenadzer(int hipId, int menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == hipId).Include(x => x.Menadzers).FirstOrDefault();

                hip.Menadzers.Add(men);

                db.Entry(hip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteMenadzer(int hipId, int menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == hipId).Include(x => x.Menadzers).FirstOrDefault();

                hip.Menadzers.Remove(men);

                db.Entry(hip).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
