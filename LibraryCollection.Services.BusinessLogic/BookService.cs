using LibraryCollection.Domain.Abstractions.Repository;
using LibraryCollection.Domain.Abstractions.Service;
using LibraryCollection.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Services.BusinessLogic
{
    public class BookService : IBookService
    {
        private IUnitOfWork unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBookList()
        {
            return (await unitOfWork.BookRepository.GetAllBookList())
                .Select(x => new BookDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    TotalCopies = x.TotalCopies,
                    CopiesInUse = x.CopiesInUse,
                    Type = x.Type,
                    ISBN = x.ISBN,
                    Category = x.Category
                });
        }
        public async Task<IEnumerable<BookDTO>> GetBookListByField(string field, string value)
        {
            return (await unitOfWork.BookRepository.GetBookListByField(field, value))
                .Select(x => new BookDTO()
                {
                    Id = x.Id,
                    Title = x.Title,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    TotalCopies = x.TotalCopies,
                    CopiesInUse = x.CopiesInUse,
                    Type = x.Type,
                    ISBN = x.ISBN,
                    Category = x.Category
                });
        }


    }
}
