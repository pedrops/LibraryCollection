using LibraryCollection.Domain.Abstractions.Repository;
using LibraryCollection.Infrastructure.DataPersistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryCollection.Infrastructure.DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookContext _context;

        public UnitOfWork()
        {
        }

        public UnitOfWork(DbContextOptions<BookContext> options)
        {
            _context = new BookContext(options);
            BookRepository = new BookRepository(_context);
        }


        public IBookRepository BookRepository { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
