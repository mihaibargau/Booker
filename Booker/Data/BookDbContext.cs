using Booker.Models;
using Microsoft.EntityFrameworkCore;
namespace Booker.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
    }
}
