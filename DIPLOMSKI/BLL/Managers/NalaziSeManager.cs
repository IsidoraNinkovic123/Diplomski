using Common.Interfaces.Managers;
using Common.Database;
using Common.Interfaces.Providers;
using DAL.Providers;
using System.Linq;

namespace BLL.Managers
{
    public class NalaziSeManager : INalaziSeManager
    {
        private INalaziSeProvider _provider;

        public NalaziSeManager()
        {
            _provider = new NalaziSeProvider();
        }

        public bool InRelation(string stavkaId)
        {
            IQueryable<Nalazi_se> entities = _provider.GetAll();
            foreach (Nalazi_se n in entities)
            {
                if (n.Stavka_menija_ID == stavkaId)
                    return true;
            }

            return false;
        }

        public void Insert(Nalazi_se entity)
        {
            _provider.Insert(entity);
        }
    }
}
