using System.ComponentModel.DataAnnotations;

namespace MoviesDataAccess.Models.Put
{
    /// <summary>
    /// Modelo de datos para actualizar géneros.
    /// </summary>
    public class GenderPutModel
    {
        /// <summary>
        /// Id del registro.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Nombre del género.
        /// </summary>
        [Required]
        public string? Name { get; set; } = null;
    }
}