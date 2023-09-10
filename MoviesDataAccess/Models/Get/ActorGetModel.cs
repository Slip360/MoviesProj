namespace MoviesDataAccess.Models.Get
{
    /// <summary>
    /// Modelo de datos que obtendrá los actores.
    /// </summary>
    public class ActorGetModel
    {
        /// <summary>
        /// Id del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del actor.
        /// </summary>
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