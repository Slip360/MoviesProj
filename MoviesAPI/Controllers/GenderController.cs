using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services.Classes;
using MoviesDataAccess.Entities;
using MoviesDataAccess.Models.Get;
using MoviesDataAccess.Models.Post;
using MoviesDataAccess.Models.Put;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenderController : ControllerBase
    {
        private readonly GenderRepository _genderRepository;

        public GenderController(GenderRepository genderRepository) =>
            _genderRepository = genderRepository;
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateGenderAsync([FromBody] GenderPostModel model)
        {
            var genderId = await _genderRepository.CreateAsync<GenderPostModel, Gender>(model);
            if(genderId == null)
                return BadRequest(string.Format("Ha habido un error al intentar crear el género {0}.", model.Name));
            return Created(string.Empty, new SuccessResponseGetModel<int>
            {
                Value = (int)genderId,
                Message = string.Format("Se ha creado correctamente el género {0}.", model.Name)
            });
        }

        [HttpGet("by-id/{genderId:int}")]
        public async Task<IActionResult> GetGenderByIdAsync(int genderId)
        {
            var model = await _genderRepository.GetModelByIdAsync<GenderGetModel, Gender>(genderId);
            if(model == null)
                return NotFound(string.Format("No se ha encontrado el género con el id {0}.", genderId));
            return Ok(new SuccessResponseGetModel<GenderGetModel>
            {
                Value = model,
                Message = string.Format("Se ha encontrado el género {0}.", model.Name)
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllGendersAsync()
        {
            var genders = await _genderRepository.GetAllModelsAsync<GenderGetModel, Gender>();
            if(genders.Any())
            {
                return Ok(new SuccessResponseGetModel<IEnumerable<GenderGetModel>>
                {
                    Value = genders,
                    Message = string.Format("Se han encontrado {0} género(s).", genders.Count())
                });
            }
            return Ok(new SuccessResponseGetModel<IEnumerable<GenderGetModel>>
            {
                Value = genders,
                Message = "No se han encontrado géneros."
            });
        }
        
        [HttpPut("edit")]
        public async Task<IActionResult> UpdateGenderAsync([FromBody] GenderPutModel model)
        {
            var result = await _genderRepository.UpdateGenderAsync(model);
            if(result)
            {
                return Ok(new SuccessResponseGetModel<object>
                {
                    Value = null,
                    Message = string.Format("Se ha actualizado correctamente el género con id {0}.", model.Id)
                });
            }
            return BadRequest("Ha habido un error al intentar actualizar el género.");
        }

        [HttpDelete("remove/{genderId:int}")]
        public async Task<IActionResult> RemoveGenderAsync(int genderId)
        {
            var result = await _genderRepository.RemoveAsync<Gender>(genderId);
            if(result)
            {
                return Ok(new SuccessResponseGetModel<object>
                {
                    Value = null,
                    Message = string.Format("Se ha eliminado correctamente el género con id {0}.", genderId)
                });
            }
            return BadRequest("Ha habido un error al eliminar el género.");
        }
    }
}