using Microsoft.EntityFrameworkCore;

namespace bookslibrary
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public string DbPath { get; }
        public LibraryContext()
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

    public class Genre
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
    }
}