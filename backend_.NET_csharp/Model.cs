using Microsoft.EntityFrameworkCore;

namespace bookslibrary
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public string DbPath { get; }
        public BookContext()
        {
            DbPath = "db/books.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
    public class Book
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? GenreID { get; set; }
    }
}