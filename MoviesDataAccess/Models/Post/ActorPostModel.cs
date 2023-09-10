namespace MoviesDataAccess.Models.Post
{
    public class ActorPostModel
    {
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
    }
}