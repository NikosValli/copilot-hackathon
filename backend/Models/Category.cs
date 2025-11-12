using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // Navigation property for one-to-many relationship
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
