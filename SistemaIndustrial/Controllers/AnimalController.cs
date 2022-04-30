using SistemaIndustrial.Base;
using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaIndustrial.Controllers
{               
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ApiBaseController
    {
        private readonly AnimalAppService animalAppService;
        public AnimalController(AnimalAppService _animalAppService)
        {
            this.animalAppService = _animalAppService;   
        }

        [HttpGet]
        public Animal GetById(int id)
        {
            var result = this.animalAppService.GetById(id);
            return result;
        }

        [HttpGet, Route("get-animal-listagem")]
        public IActionResult GetListagem(int pageSize = 10, int pageIndex = 0, string? pesquisa = null)
        {
            var result = this.animalAppService.GetAll(pesquisa, pageSize, pageIndex);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Animal animal)
        {
            var result = await this.animalAppService.Save(animal);
            if (result == null)
            {
                return Response(this.animalAppService.ApplicationErrors);
            }
            return Response(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Animal result = animalAppService.GetById(id);

                if (result == null)
                {
                    return NotFound($"Animal com o Id = {id} não foi encontrado");
                }

                animalAppService.Delete(id);
                return Ok(new { message = "Animal Excluído" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir Animal");
            }
        }
    }
}
