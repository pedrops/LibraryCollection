using LibraryCollection.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryCollection.Domain.Abstractions.Repository
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBookList();
        Task<IEnumerable<Book>> GetBookListByField(string field, string value);
    }
}
