using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoviesDataAccess.Interfaces;

namespace MoviesDataAccess.Entities
{
    /// <summary>
    /// Entidad para géneros.
    /// </summary>
    public class Gender : IRequiredFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del género.
        /// </summary>
        [Required]
        public string? Name { get; set; } = null;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}