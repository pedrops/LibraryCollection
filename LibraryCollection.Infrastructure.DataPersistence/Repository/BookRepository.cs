using LibraryCollection.Domain.Abstractions.Repository;
using LibraryCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Infrastructure.DataPersistence.Repository
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAllBookList()
        {
            return await _context.Set<Book>().ToListAsync();

        }

        public async Task<IEnumerable<Book>> GetBookListByField(string field, string value)
        {
            List<Book> books;
            if (string.IsNullOrEmpty(value))
                return await GetAllBookList();

            var search = value.ToLower();
            switch (field.ToLower())
            {
                case "title":
                    books = await _context.Set<Book>().Where(x => x.Title.ToLower().Contains(search)).ToListAsync();
                    break;
                case "first name":
                    books = await _context.Set<Book>().Where(x => x.FirstName.ToLower().Contains(search)).ToListAsync();
                    break;
                case "last name":
                    books = await _context.Set<Book>().Where(x => x.LastName.ToLower().Contains(search)).ToListAsync();
                    break;
                case "type":
                    books = await _context.Set<Book>().Where(x => x.Type.ToLower().Contains(search)).ToListAsync();
                    break;
                case "isbn":
                    books = await _context.Set<Book>().Where(x => x.ISBN.ToLower().Contains(search)).ToListAsync();
                    break;
                case "category":
                    books = await _context.Set<Book>().Where(x => x.Category.ToLower().Contains(search)).ToListAsync();
                    break;
                default:
                    books = new List<Book>();
                    break;
            }
            return books;
        }
    }
}
