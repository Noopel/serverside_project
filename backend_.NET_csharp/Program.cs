using Microsoft.EntityFrameworkCore;
using bookslibrary;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {});
var app = builder.Build();
app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

await using var db = new LibraryContext();
Console.WriteLine($"Database path: {db.DbPath}");

app.MapGet("/", () => 
{
    return Results.Ok("Welcome to the LibraryApi");
});

app.MapGet("/books", async () =>
{
    var data = await db.Books.ToListAsync();
    
    return Results.Ok(data);
});

app.MapPost("/books", async (Book book) =>
{
    await db.Books.AddAsync(book);
    await db.SaveChangesAsync();

    return Results.Created();
});

app.MapGet("/books/{id}", async (int id) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null) return Results.NotFound();

    return Results.Ok(book);
});

app.MapPut("/books/{id}", async (int id, Book inputBook) =>
{
    var book = await db.Books.FindAsync(id);

    if(book == null) return Results.NotFound();

    book.Title = inputBook.Title;
    book.Description = inputBook.Description;
    book.GenreID = inputBook.GenreID;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/books/{id}", async (int id) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapGet("/genres", async () =>
{
    var genres = await db.Genres.ToListAsync();

    return Results.Ok(genres);
});

app.MapGet("/genres/books/{id}", async (int id) =>
{
    var genre = await db.Genres.Where((genre) => genre.ID == id).SingleAsync();
    var books = await db.Books.Where((book) => book.GenreID == id).ToListAsync();

    GenreAndBooks genreAndBooks = new GenreAndBooks(genre, books);

    return Results.Ok(genreAndBooks);
});


app.Run();

public class GenreAndBooks
{
    public Genre genre { get; set; }
    public List<Book> books { get; set; }

    public GenreAndBooks (Genre providedGenre, List<Book> providedBooks) {
        genre = providedGenre;
        books = providedBooks;
 }
}