using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using backend.Data;
using backend.Models;
using System.Linq;

namespace backend.Tests;

public class MoviesEndpointLogicTests
{
    private DbContextOptions<MovieContext> _options;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<MovieContext>()
            .UseInMemoryDatabase(databaseName: "TestMovieDb_Movies")
            .Options;
    }

    [Test]
    public async Task MoviesLogic_ReturnsAllMoviesWithCategories()
    {
        // Arrange
        using var db = new MovieContext(_options);
        var action = new Category { Name = "Action" };
        var comedy = new Category { Name = "Comedy" };
        db.Categories.AddRange(action, comedy);
        await db.SaveChangesAsync();

        db.Movies.AddRange(
            new Movie { Title = "Die Hard", CategoryId = action.Id },
            new Movie { Title = "Rush Hour", CategoryId = comedy.Id }
        );
        await db.SaveChangesAsync();

        // Act (simulate /movies logic)
        var movies = await db.Movies.Include(m => m.Category).ToListAsync();

        // Assert
        Assert.That(movies.Count, Is.EqualTo(2));
        Assert.That(movies.Any(m => m.Title == "Die Hard"));
        Assert.That(movies.Any(m => m.Title == "Rush Hour"));
        Assert.That(movies.All(m => m.Category != null));
        Assert.That(movies.Any(m => m.Category.Name == "Action"));
        Assert.That(movies.Any(m => m.Category.Name == "Comedy"));
    }
}
