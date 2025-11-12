using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        // Foreign key for Category
        [Required]
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
            // Navigation property for many-to-many with MovieUser
            public List<MovieUser> MovieUsers { get; set; } = new List<MovieUser>();

            // Navigation property for many-to-many with Favorites
            public List<Favorites> FavoritesLists { get; set; } = new List<Favorites>();
    }
}
