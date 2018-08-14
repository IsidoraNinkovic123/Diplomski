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
                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new Entities())
            {
                Menadzer menadzer = db.Menadzers.Where(m => m.MBR.Equals(id)).FirstOrDefault();

                db.Entry(menadzer).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Menadzer GetById(string id)
        {
            using (var db = new Entities())
            {
                Menadzer menadzer = db.Menadzers.Where(m => m.MBR.Equals(id)).Include(x => x.Zaposleni).FirstOrDefault();

                return menadzer;
            }
        }

        public IQueryable<Menadzer> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Menadzers.Include(x => x.Zaposleni);
            }
        }

        public void AddHipermarket(int hipId, string menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == hipId).FirstOrDefault();

                men.Hipermarkets.Add(hip);

                db.Entry(men).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteHipermarket(int hipId, string menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Hipermarket hip = db.Hipermarkets.Where(h => h.ID == hipId).FirstOrDefault();

                men.Hipermarkets.Remove(hip);

                db.Entry(men).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void AddDobavljac(int dobId, string menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == dobId).FirstOrDefault();

                men.Dobavljac_robe.Add(dob);

                db.Entry(men).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteDobavljac(int dobId, string menId)
        {
            using (var db = new Entities())
            {
                Menadzer men = db.Menadzers.Where(m => m.MBR == menId).FirstOrDefault();
                Dobavljac_robe dob = db.Dobavljac_robe.Where(d => d.ID == dobId).FirstOrDefault();

                men.Dobavljac_robe.Remove(dob);

                db.Entry(men).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
