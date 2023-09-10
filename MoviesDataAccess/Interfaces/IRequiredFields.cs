namespace MoviesDataAccess.Interfaces
{
    /// <summary>
    /// Interfaz que debe implementar cualquier entitdad.
    /// </summary>
    public interface IRequiredFields
    {
        /// <summary>
        /// Id del registro.
        /// </summary>
        public int Id { get; set; }

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