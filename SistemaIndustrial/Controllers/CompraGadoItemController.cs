using SistemaIndustrial.Base;
using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaIndustrial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraGadoItemController : ApiBaseController
    {
        private readonly CompraGadoItemAppService compraGadoItemAppService; 
        public CompraGadoItemController(CompraGadoItemAppService _compraGadoItemAppService)
        {
            this.compraGadoItemAppService = _compraGadoItemAppService;   
        }

        [HttpGet]
        public CompraGadoItem GetById(int id)
        {
            var result = this.compraGadoItemAppService.GetById(id);
            return result;
        }

        [HttpGet, Route("get-compragadoitem-listagem")]
        public IActionResult GetAll(int pageSize = 10, int pageIndex = 0, string? pesquisa = null)
        {
            var result = this.compraGadoItemAppService.GetAll(pesquisa, pageSize, pageIndex);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(CompraGadoItem compraGadoItem)
        {
            var result = await this.compraGadoItemAppService.Save(compraGadoItem);
            if (result == null)
            {
                return Response(this.compraGadoItemAppService.ApplicationErrors);
            }
            return Response(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                CompraGadoItem result = compraGadoItemAppService.GetById(id);

                if (result == null)
                {
                    return NotFound($"Item de Compra com o Id = {id} não foi encontrado");
                }

                compraGadoItemAppService.Delete(id);
                return Ok(new { message = "Item de Compra Excluído" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir item de compra");
            }
        }
    }
}
