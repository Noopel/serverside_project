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

await using var db = new BookContext();
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

app.MapDelete("books/{id}", async (int id) =>
{
    var book = await db.Books.FindAsync(id);

    if (book == null) return Results.NotFound();

    db.Books.Remove(book);
    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();
