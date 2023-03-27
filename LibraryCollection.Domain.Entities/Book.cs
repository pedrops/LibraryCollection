using LibraryCollection.Domain.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryCollection.Domain.Entities
{
    public class Book
    {

        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("total_copies")]
        public int TotalCopies { get; set; }
        [Column("copies_in_use")]
        public int CopiesInUse { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("isbn")]
        public string ISBN { get; set; }
        [Column("category")]
        public string Category { get; set; }

        public Book()
        { }

        public Book(IBook dto)
        {
            Title = dto.Title;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            TotalCopies = dto.TotalCopies;
            CopiesInUse = dto.CopiesInUse;
            Type = dto.Type;
            ISBN = dto.ISBN;
            Category = dto.Category;
        }
    }
}
