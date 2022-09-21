using System.Collections.Generic;

namespace CM.Customers
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity entity);
        TEntity Read(int? entityCode);
        void Update(TEntity entity);
        void Delete(int entityCode);
        void DeleteAll();
        List<TEntity> GetAll();
    }
}
