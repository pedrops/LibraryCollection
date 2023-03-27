using System.Collections.Generic;

namespace LibraryCollection.Domain.Abstractions.Repository
{
    public interface IBaseRepository<IEntity> where IEntity : class
    {
        IEntity Get(string id);
        IEnumerable<IEntity> GetAll();
        void Add(IEntity entity);
        void Remove(IEntity entity);
        void Update(IEntity entity);
    }
}
