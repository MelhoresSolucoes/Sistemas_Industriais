using SistemaIndustrial.Base;
using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaIndustrial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PecuaristaController : ApiBaseController
    {
        private readonly PecuaristaAppService pecuaristaAppService;
        public PecuaristaController(PecuaristaAppService _pecuaristaAppService)
        {
            this.pecuaristaAppService = _pecuaristaAppService;
        }

        [HttpGet]
        public Pecuarista GetById(int id)
        {
            var result = this.pecuaristaAppService.GetById(id);
            return result;
        }

        [HttpGet, Route("get-pecuarista-listagem")]
        public IActionResult GetListagem(int pageSize = 10, int pageIndex = 0, string? pesquisa = null)
        {
            var result = this.pecuaristaAppService.GetAll(pesquisa, pageSize, pageIndex);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Pecuarista pecuarista)
        {
            var result = await this.pecuaristaAppService.Save(pecuarista);
            if (result == null)
            {
                return Response(this.pecuaristaAppService.ApplicationErrors);
            }
            return Response(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                Pecuarista result = pecuaristaAppService.GetById(id);

                if (result == null)
                {
                    return NotFound($"Pecuarista com o Id = {id} não foi encontrado");
                }

                pecuaristaAppService.Delete(id);
                return Ok(new { message = "Pecuarista Excluído" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir Pecuarista");
            }
        }
    }
}
