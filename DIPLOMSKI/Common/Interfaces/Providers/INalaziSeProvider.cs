using Common.Database;
using System.Linq;

namespace Common.Interfaces.Providers
{
    public interface INalaziSeProvider
    {
        void Insert(Nalazi_se entity);
        IQueryable<Nalazi_se> GetAll();
    }
}
