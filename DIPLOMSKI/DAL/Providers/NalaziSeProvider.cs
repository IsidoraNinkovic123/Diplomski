using Common.Database;
using Common.Interfaces.Providers;
using System.Linq;

namespace DAL.Providers
{
    public class NalaziSeProvider : INalaziSeProvider
    {
        public void Insert(Nalazi_se entity)
        {
            using (var db = new Entities())
            {
                db.Nalazi_se.Add(entity);
                db.SaveChanges();
            }
        }

        /*public IQueryable<Nalazi_se> GetAll()
        {
            using (var db = new Entities())
            {
                return db.Nalazi_se;
            }
        }*/
    }
}
