using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helpers;
using MoviesDataAccess.Interfaces;

namespace MoviesAPI.Services.Classes
{
    /// <summary>
    /// Repositorio para las operaciones básicas de cualquier entidad.
    /// </summary>
    public class Respository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public Respository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Elimina un registro de cualquier tabla de la base de datos. Es un borrado lógico.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a la que será accedida a través del "DbContext".</typeparam>
        /// <param name="entityId">Id de la entidad a eliminar.</param>
        /// <returns>Tarea que retorna true si fue eliminado en caso contrario false.</returns>
        public async Task<bool> RemoveAsync<TEntity>(int entityId) where TEntity : class, IRequiredFields
        {
            try
            {
                var entity = await GetEntityByIdAsync<TEntity>(entityId);
                if(entity == null)
                    return false;
                _applicationDbContext.Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Crea un registro en cualquier tabla de la base de datos.
        /// </summary>
        /// <typeparam name="TPostModel">Tipo del modelo que traerá los datos de la entidad para la creación</typeparam>
        /// <typeparam name="TEntity">Tipo de la entidad a la que será accedida a través del "DbContext".</typeparam>
        /// <param name="model">Datos del modelo de la entidad que será mapeada para ser creada.</param>
        /// <returns>Id del registro creado.</returns>
        public async Task<int?> CreateAsync<TPostModel, TEntity>(TPostModel model) where TPostModel : class where TEntity : class, IRequiredFields
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);
                await _applicationDbContext.AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();
                return entity.Id;
            }
            catch(Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Obtiene como entidad un registro de cualquier tabla de la base de datos. En caso de no encontrar el registro obtiene null.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad a la que será accedida a través del "DbContext".</typeparam>
        /// <param name="entityId">Id de la entidad.</param>
        /// <returns>Tarea que retorna la entidad con los datos.</returns>
        public async Task<TEntity?> GetEntityByIdAsync<TEntity>(int entityId) where TEntity : class, IRequiredFields =>
            await _applicationDbContext.FindAsync<TEntity>(entityId);

        /// <summary>
        /// Obtiene como modelo un registro de cualquier tabla de la base de datos. En caso de no encontrar el registro obtiene null.
        /// </summary>
        /// <typeparam name="TGetModel"> Tipo del modelo que devolverá los datos de la entidad para la obtención.</typeparam>
        /// <typeparam name="TEntity">Tipo de la entidad a la que será accedida a través del "DbContext".</typeparam>
        /// <param name="entityId">Id de la entidad.</param>
        /// <returns>Tarea que retorna el modelo con los datos.</returns>
        public async Task<TGetModel?> GetModelByIdAsync<TGetModel, TEntity>(int entityId) where TGetModel : class where TEntity : class, IRequiredFields
        {
            var entity = await GetEntityByIdAsync<TEntity>(entityId);
            return entity == null ? null : _mapper.Map<TGetModel>(entity);
        }

        /// <summary>
        /// Obtiene todas las entidades de cualquier tabla de la base de datos.
        /// </summary>
        /// <typeparam name="TGetModel">Tipo del modelo que retornará los datos.</typeparam>
        /// <typeparam name="TEntity">Tipo de la entidad que se obtendrán los datos.</typeparam>
        /// <returns>Tarea que retorna los registros.</returns>
        public async Task<IEnumerable<TGetModel>> GetAllModelsAsync<TGetModel, TEntity>() where TGetModel : class where TEntity : class, IRequiredFields =>
            _mapper.Map<List<TGetModel>>(await _applicationDbContext.Set<TEntity>().ToListAsync());
    }
}