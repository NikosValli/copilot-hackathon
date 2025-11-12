using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;

var builder = WebApplication.CreateBuilder(args);
// Add CORS policy to allow frontend requests
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add DbContext with in-memory database
builder.Services.AddDbContext<backend.Data.MovieContext>(options =>
    options.UseInMemoryDatabase("MovieDb"));

// Configure JSON serialization to handle cycles
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
// Use CORS policy
app.UseCors("AllowFrontend");

// Seed endpoint: POST /seed
app.MapPost("/seed", async (MovieContext db) =>
{
    // Remove existing data
    db.Categories.RemoveRange(db.Categories);
    db.Movies.RemoveRange(db.Movies);
    await db.SaveChangesAsync();

    // MCP movie list
    var mcpMovies = new[]
    {
        new { Title = "Inception", Director = "Christopher Nolan", Year = 2010, Genre = "Sci-Fi" },
        new { Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Genre = "Crime" },
        new { Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994, Genre = "Crime" },
        new { Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994, Genre = "Drama" },
        new { Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Genre = "Action" }
    };

    // Create categories from genres
    var genres = mcpMovies.Select(m => m.Genre).Distinct().ToList();
    var categoryDict = new Dictionary<string, Category>();
    foreach (var genre in genres)
    {
        var category = new Category { Name = genre };
        db.Categories.Add(category);
        categoryDict[genre] = category;
    }
    await db.SaveChangesAsync();

    // Add movies with correct CategoryId
    foreach (var m in mcpMovies)
    {
        var category = categoryDict[m.Genre];
        db.Movies.Add(new Movie { Title = m.Title, CategoryId = category.Id });
    }
    await db.SaveChangesAsync();

    // Return all movies with categories
    var movies = await db.Movies.Include(m => m.Category).ToListAsync();
    return Results.Ok(movies);
});

// Get movies endpoint: GET /movies
app.MapGet("/movies", async (MovieContext db) =>
{
    var movies = await db.Movies.Include(m => m.Category).ToListAsync();
    return Results.Ok(movies);
});



app.Run();

// Make Program class available for testing
public partial class Program { }
