using AutoMapper;
using MoviesAPI.Helpers;
using MoviesDataAccess.Entities;
using MoviesDataAccess.Models.Put;

namespace MoviesAPI.Services.Classes
{
    /// <summary>
    /// Repositorio para administrar la tabla "Actors".
    /// </summary>
    public class ActorRepository : Respository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public ActorRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Edita un actor.
        /// </summary>
        /// <param name="model">Datos del actor a editar.</param>
        /// <returns>Tarea que retorna true si se actualizó correctamente en caso contrario false.</returns>
        public async Task<bool> UpdateActorAsync(ActorPutModel model)
        {
            try
            {
                var actor = await GetEntityByIdAsync<Actor>(model.Id);
                if(actor == null)
                    return false;
                
                actor.BirthDay = model.BirthDay;
                actor.Name = model.Name;
                actor.Photo = model.Photo;
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}