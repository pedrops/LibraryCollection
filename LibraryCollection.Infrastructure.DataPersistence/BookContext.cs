using LibraryCollection.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCollection.Infrastructure.DataPersistence
{
    public class BookContext : DbContext
    {

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
