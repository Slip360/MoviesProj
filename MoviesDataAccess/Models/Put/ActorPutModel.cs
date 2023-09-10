using System.ComponentModel.DataAnnotations;

namespace MoviesDataAccess.Models.Put
{
    /// <summary>
    /// Modelo de datos para editar un actor.
    /// </summary>
    public class ActorPutModel
    {
        /// <summary>
        /// Id del registro.
        /// </summary>
        [Required]
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

        /// <summary>
        /// Fecha de creación.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha de actualización.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}