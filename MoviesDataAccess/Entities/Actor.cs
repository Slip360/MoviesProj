using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MoviesDataAccess.Interfaces;

namespace MoviesDataAccess.Entities
{
    /// <summary>
    /// Entidad para actores.
    /// </summary>
    public class Actor : IRequiredFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del actor.
        /// </summary>
        [Required]
        public string? Name { get; set; } = null;

        /// <summary>
        /// Fecha de nacimineto del actor.
        /// </summary>
        public DateTime? BirthDay { get; set; } = null;

        /// <summary>
        /// Url de la foto del actor.
        /// </summary>
        public string? Photo { get; set; } = null;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}