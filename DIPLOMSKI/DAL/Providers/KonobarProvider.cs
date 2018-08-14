﻿using System.Linq;
using System.Data.Entity;
using Common.Database;
using Common.Interfaces.Providers;

namespace DAL.Providers
{
    public class KonobarProvider : IKonobarProvider
    {
        public void Insert(Konobar entity)
        {
            using (var db = new Entities())
            {
                db.Konobars.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(Konobar entity)
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
                Konobar kon = db.Konobars.Where(k => k.MBR.Equals(id)).FirstOrDefault();

                db.Entry(kon).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Konobar GetById(string id)
        {
            using (var db = new Entities())
            {
                Konobar kon = db.Konobars.Where(k => k.MBR.Equals(id)).Include(x => x.Zaposleni).FirstOrDefault();

                return kon;
            }
        }

        public IQueryable<Konobar> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Konobars.Include(x => x.Zaposleni);
            }
        }
    }
}