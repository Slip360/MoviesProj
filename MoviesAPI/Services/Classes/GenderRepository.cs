using AutoMapper;
using MoviesAPI.Helpers;
using MoviesDataAccess.Entities;
using MoviesDataAccess.Models.Put;

namespace MoviesAPI.Services.Classes
{
    /// <summary>
    /// Repositorio para administrar al tabla de "Genders".
    /// </summary>
    public class GenderRepository : Respository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public GenderRepository(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Edita un género.
        /// </summary>
        /// <param name="model">Datos del género a editar.</param>
        /// <returns>Tarea que retorna true si se actualizó correctamente en caso contrario false.</returns>
        public async Task<bool> UpdateGenderAsync(GenderPutModel model)
        {
            try
            {
                var gender = await GetEntityByIdAsync<Gender>(model.Id);
                if(gender == null)
                    return false;

                gender.Name = model.Name;
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