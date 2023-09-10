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
    public class ActorController : ControllerBase
    {
        private readonly ActorRepository _actorRepository;

        public ActorController(ActorRepository actorRepository) =>
            _actorRepository = actorRepository;
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateActorAsync([FromBody] ActorPostModel model)
        {
            var actorId = await _actorRepository.CreateAsync<ActorPostModel, Actor>(model);
            if(actorId == null)
                return BadRequest(string.Format("Ha habido un error al intentar crear el actor {0}.", model.Name));
            return Created(string.Empty, new SuccessResponseGetModel<int>
            {
                Value = (int)actorId,
                Message = string.Format("Se ha creado correctamente el actor {0}.", model.Name)
            });
        }

        [HttpGet("by-id/{actorId:int}")]
        public async Task<IActionResult> GetActorByIdAsync(int actorId)
        {
            var model = await _actorRepository.GetModelByIdAsync<ActorGetModel, Actor>(actorId);
            if(model == null)
                return NotFound(string.Format("No se ha encontrado el actor con el id {0}.", actorId));
            return Ok(new SuccessResponseGetModel<ActorGetModel>
            {
                Value = model,
                Message = string.Format("Se ha encontrado el actor {0}", model.Name)
            });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllActorsAsync()
        {
            var actors = await _actorRepository.GetAllModelsAsync<ActorGetModel, Actor>();
            if(actors.Any())
            {
                return Ok(new SuccessResponseGetModel<IEnumerable<ActorGetModel>>
                {
                    Value = actors,
                    Message = string.Format("Se han encontrado {0} actor(es).", actors.Count())
                });
            }
            return Ok(new SuccessResponseGetModel<IEnumerable<ActorGetModel>>
            {
                Value = actors,
                Message = "No se han encontrado actores."
            });
        }

        [HttpPut("edit")]
        public async Task<IActionResult> UpdateActorAsync([FromBody] ActorPutModel model)
        {
            var result = await _actorRepository.UpdateActorAsync(model);
            if(result)
            {
                return Ok(new SuccessResponseGetModel<object>
                {
                    Value = null,
                    Message = string.Format("Se ha actualizado correctamente el actor con id {0}.", model.Id)
                });
            }
            return BadRequest("Ha habido un error al intentar actualizar el actor.");
        }

        [HttpDelete("remove/{actorId:int}")]
        public async Task<IActionResult> RemoveActorAsync(int actorId)
        {
            var result = await _actorRepository.RemoveAsync<Actor>(actorId);
            if(result)
            {
                return Ok(new SuccessResponseGetModel<object>
                {
                    Value = null,
                    Message = string.Format("Se ha eliminado correctamente el actor con id {0}.", actorId)
                });
            }
            return BadRequest("Ha habido un error al eliminar el actor.");
        }
    }
}