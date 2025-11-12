using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Favorites
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property for many-to-many relationship with Movie
        public List<Movie> Movies { get; set; } = new List<Movie>();
            // Foreign key for MovieUser (optional, if you want to track owner)
            public int MovieUserId { get; set; }
            public MovieUser MovieUser { get; set; }
    }
}
// Checklist (x for done):
// - [x] Create class structure
// - [x] Implement navigation properties if needed
// - [x] Add data annotations for validation
