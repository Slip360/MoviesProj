using System.ComponentModel.DataAnnotations;

namespace MoviesDataAccess.Models.Post
{
    /// <summary>
    /// Modelo de datos para crear géneros.
    /// </summary>
    public class GenderPostModel
    {
        /// <summary>
        /// Nombre del género.
        /// </summary>
        [Required]
        public string? Name { get; set; } = null;
    }
}