using AutoMapper;
using MoviesDataAccess.Entities;
using MoviesDataAccess.Models.Get;
using MoviesDataAccess.Models.Post;

namespace MoviesAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // ------------------------------------ Géneros ------------------------------------
            CreateMap<GenderPostModel, Gender>();
            CreateMap<Gender, GenderGetModel>();
            // ---------------------------------------------------------------------------------
        }
    }
}