using Common.Database;

namespace Common.Interfaces.Managers
{
    public interface INalaziSeManager
    {
        void Insert(Nalazi_se entity);
        bool InRelation(string stavkaId);
    }
}
