using System;

namespace LibraryCollection.Domain.Abstractions.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository BookRepository { get; }
        int Complete();
    }
}
