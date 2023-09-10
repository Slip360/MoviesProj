namespace MoviesDataAccess.Models.Get
{
    /// <summary>
    /// Modelo de datos para obtener géneros.
    /// </summary>
    public class GenderGetModel
    {
        /// <summary>
        /// Id del registro.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del género.
        /// </summary>
        public string? Name { get; set; } = null;

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