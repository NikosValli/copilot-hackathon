using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using backend.Models;

namespace backend.Tests;

public class BackendEndpointsTests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:5065/"); // Backend server URL from launch settings
    }

    [TearDown]
    public void TearDown()
    {
        _client?.Dispose();
    }

    [Test]
    public async Task SeedEndpoint_ShouldSeedAndReturnMovies()
    {
        try
        {
            var response = await _client.PostAsync("/seed", null);
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();
            Assert.That(movies, Is.Not.Null);
            Assert.That(movies.Count, Is.GreaterThanOrEqualTo(2));
            Assert.That(movies.Any(m => m.Title == "Die Hard"), Is.True);
            Assert.That(movies.Any(m => m.Title == "Rush Hour"), Is.True);
        }
        catch (HttpRequestException)
        {
            Assert.Ignore("Backend server not running. Start with 'dotnet run --project backend' first.");
        }
    }

    [Test]
    public async Task MoviesEndpoint_ShouldListMovies()
    {
        try
        {
            // Seed first
            await _client.PostAsync("/seed", null);
            var response = await _client.GetAsync("/movies");
            response.EnsureSuccessStatusCode();
            var movies = await response.Content.ReadFromJsonAsync<List<Movie>>();
            Assert.That(movies, Is.Not.Null);
            Assert.That(movies.Count, Is.GreaterThanOrEqualTo(2));
            Assert.That(movies.Any(m => m.Title == "Die Hard"), Is.True);
            Assert.That(movies.Any(m => m.Title == "Rush Hour"), Is.True);
        }
        catch (HttpRequestException)
        {
            Assert.Ignore("Backend server not running. Start with 'dotnet run --project backend' first.");
        }
    }
}
