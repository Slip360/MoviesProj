namespace MoviesDataAccess.Models.Get
{
    /// <summary>
    /// Modelo de datos que contiene la respuesta hacia el cliente.
    /// </summary>
    /// <typeparam name="TModel">Tipo del modelo de los datos que se enviarán.</typeparam>
    public class SuccessResponseGetModel<TModel>
    {
        public string Message { get; set; } = string.Empty;
        public TModel? Value { get; set; } = default;
    }
}