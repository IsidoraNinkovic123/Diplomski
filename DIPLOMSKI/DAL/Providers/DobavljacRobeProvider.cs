using System.Linq;
using Common.Database;
using Common.Interfaces.Providers;
using System.Data.Entity;

namespace DAL.Providers
{
    public class DobavljacRobeProvider : IDobavljacRobeProvider
    {
        private Entities db = new Entities();

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
                Dobavljac_robe toChange = db.Dobavljac_robe.Where(x => x.ID == entity.ID).FirstOrDefault();
                toChange.NAZ = entity.NAZ;
                toChange.TEL = entity.TEL;
                toChange.VR_ROBE = entity.VR_ROBE;

                db.Entry(toChange).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new Entities())
            {
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == id).Include(x => x.Menadzers).FirstOrDefault();
                dob.Menadzers.Clear();
                db.Entry(dob).State = System.Data.Entity.EntityState.Modified;

                db.Entry(dob).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Dobavljac_robe GetById(int id)
        {
            Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == id).Include(x => x.Menadzers).FirstOrDefault();
            return dob;
        }

        public IQueryable<Dobavljac_robe> GetAll()
        {
            return db.Dobavljac_robe.Include(x => x.Menadzers);
        }

        public void AddMenadzer(int dobId, int menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == dobId).Include(x => x.Menadzers).FirstOrDefault();

                dob.Menadzers.Add(men);

                db.Entry(dob).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteMenadzer(int dobId, int menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == dobId).Include(x => x.Menadzers).FirstOrDefault();

                dob.Menadzers.Remove(men);

                db.Entry(dob).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
