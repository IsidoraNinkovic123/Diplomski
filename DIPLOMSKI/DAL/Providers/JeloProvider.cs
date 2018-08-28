using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class JeloProvider : IJeloProvider
    {
        public void Insert(Jelo entity)
        {
            using (var db = new Entities())
            {
                db.Jeloes.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Jelo entity)
        {
            using (var db = new Entities())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                Stavka_menija stavka = db.Stavka_menija.Where(s => s.ID.Equals(entity.ID)).FirstOrDefault();
                db.Entry(stavka).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }

        public void Delete(string id)
        {
            using (var db = new Entities())
            {
                Jelo jelo = db.Jeloes.Where(j => j.ID.Equals(id)).Include(x => x.Stavka_menija).Include(x => x.Kuvars).Include(x => x.Sastojaks).FirstOrDefault();
                jelo.Kuvars.Clear();
                jelo.Sastojaks.Clear();             
                db.Entry(jelo).State = System.Data.Entity.EntityState.Modified;

                db.Entry(jelo).State = System.Data.Entity.EntityState.Deleted;

                Stavka_menija stavka = db.Stavka_menija.Where(s => s.ID.Equals(id)).FirstOrDefault();
                stavka.Nalazi_se.Clear();
                db.Entry(stavka).State = System.Data.Entity.EntityState.Modified;

                db.Entry(stavka).State = System.Data.Entity.EntityState.Deleted;

                db.SaveChanges();
            }
        }

        public Jelo GetById(string id)
        {
            using (var db = new Entities())
            {
                Jelo jelo = db.Jeloes.Where(j => j.ID.Equals(id)).Include(x => x.Stavka_menija).FirstOrDefault();

                return jelo;
            }
        }

        public IQueryable<Jelo> GetAll()
        {
            Entities db = new Entities();
            return db.Jeloes.Include(x => x.Stavka_menija).Include(x => x.Kuvars).Include(x => x.Sastojaks);
        }

        public void AddSastojak(int sastojakId, string jeloId)
        {
            using (var db = new Entities())
            {
                Jelo jelo = db.Jeloes.Where(j => j.ID == jeloId).Include(x => x.Sastojaks).FirstOrDefault();
                Sastojak sastojak = db.Sastojaks.Where(s => s.ID == sastojakId).FirstOrDefault();

                jelo.Sastojaks.Add(sastojak);

                db.Entry(jelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteSastojak(int sastojakId, string jeloId)
        {
            using (var db = new Entities())
            {
                Jelo jelo = db.Jeloes.Where(j => j.ID == jeloId).Include(x => x.Sastojaks).FirstOrDefault();
                Sastojak sastojak = db.Sastojaks.Where(s => s.ID == sastojakId).FirstOrDefault();

                jelo.Sastojaks.Remove(sastojak);

                db.Entry(jelo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
