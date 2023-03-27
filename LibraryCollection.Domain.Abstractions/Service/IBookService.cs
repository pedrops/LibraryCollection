using LibraryCollection.Domain.Entities.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryCollection.Domain.Abstractions.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBookList();
        Task<IEnumerable<BookDTO>> GetBookListByField(string field, string value);
    }
}
