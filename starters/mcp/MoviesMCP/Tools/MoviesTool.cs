using System.ComponentModel;
using ModelContextProtocol.Server;

namespace MoviesMCP.Tools;

[McpServerToolType]
public class MoviesTool
{
    public record MovieInfo(string Title, string Director, int Year, string Genre);
    
    private static readonly List<MovieInfo> MoviesDatabase = new()
    {
        new MovieInfo("Inception", "Christopher Nolan", 2010, "Sci-Fi"),
        new MovieInfo("The Godfather", "Francis Ford Coppola", 1972, "Crime"),
        new MovieInfo("Pulp Fiction", "Quentin Tarantino", 1994, "Crime"),
        new MovieInfo("The Shawshank Redemption", "Frank Darabont", 1994, "Drama"),
        new MovieInfo("The Dark Knight", "Christopher Nolan", 2008, "Action")
    };
    
    [McpServerTool(Name = "get_movies", Title = "Get Movies")]
    [Description("Returns list of movies.")]
    public static MovieInfo[] GetMovies()
    {
        return MoviesDatabase.ToArray();
    }

    [McpServerTool(Name = "get_movie_info", Title = "Get Movie Info")]
    [Description("Returns information about a movie given its title.")]
    public static MovieInfo? GetMovieInfo(string title) => MoviesDatabase.FirstOrDefault(m => m.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

    [McpServerTool(Name = "list_movies_by_genre", Title = "List Movies by Genre")]
    [Description("Returns a list of movies in a given genre.")]
    public static List<MovieInfo> ListMoviesByGenre(string genre) =>
        MoviesDatabase
            .Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
            .ToList();
}
