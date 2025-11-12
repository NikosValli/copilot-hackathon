using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using backend.Data;
using backend.Models;
using System.Linq;

namespace backend.Tests;

public class SeedEndpointLogicTests
{
    private DbContextOptions<MovieContext> _options;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<MovieContext>()
            .UseInMemoryDatabase(databaseName: "TestMovieDb")
            .Options;
    }

    [Test]
    public async Task SeedLogic_RemovesAndAddsMoviesAndCategories()
    {
        // Arrange
        using var db = new MovieContext(_options);
        db.Categories.Add(new Category { Name = "OldCategory" });
        db.Movies.Add(new Movie { Title = "OldMovie", CategoryId = 1 });
        await db.SaveChangesAsync();

        // Act (simulate /seed logic)
        db.Categories.RemoveRange(db.Categories);
        db.Movies.RemoveRange(db.Movies);
        await db.SaveChangesAsync();

        var action = new Category { Name = "Action" };
        var comedy = new Category { Name = "Comedy" };
        db.Categories.AddRange(action, comedy);
        await db.SaveChangesAsync();

        db.Movies.AddRange(
            new Movie { Title = "Die Hard", CategoryId = action.Id },
            new Movie { Title = "Rush Hour", CategoryId = comedy.Id }
        );
        await db.SaveChangesAsync();

        // Assert
        var movies = await db.Movies.Include(m => m.Category).ToListAsync();
        Assert.That(movies.Count, Is.EqualTo(2));
        Assert.That(movies.Any(m => m.Title == "Die Hard"));
        Assert.That(movies.Any(m => m.Title == "Rush Hour"));
        Assert.That(movies.All(m => m.Category != null));
        var categories = db.Categories.ToList();
        Assert.That(categories.Count, Is.EqualTo(2));
        Assert.That(categories.Any(c => c.Name == "Action"));
        Assert.That(categories.Any(c => c.Name == "Comedy"));
    }
}
