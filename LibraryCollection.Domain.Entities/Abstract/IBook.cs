using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryCollection.Domain.Entities.Abstract
{
    public interface IBook : IEntityBase
    {
        string Title { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int TotalCopies { get; set; }
        int CopiesInUse { get; set; }
        string Type { get; set; }
        string ISBN { get; set; }
        string Category { get; set; }
    }
}
