using SistemaIndustrial.Base;
using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Services;
using Microsoft.AspNetCore.Mvc;

namespace SistemaIndustrial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraGadoController : ApiBaseController
    {
        private readonly CompraGadoAppService compraGadoAppService; 
        public CompraGadoController(CompraGadoAppService _compraGadoAppService)
        {
            this.compraGadoAppService = _compraGadoAppService;   
        }

        [HttpGet]
        public CompraGado GetById(int id)
        {
            var result = this.compraGadoAppService.GetById(id);
            return result;
        }

        [HttpGet, Route("get-compragado-listagem")]
        public IActionResult GetAll(int pageSize = 10, int pageIndex = 0, string? pesquisa = null)
        {
            var result = this.compraGadoAppService.GetAll(pesquisa, pageSize, pageIndex);
            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(CompraGado compraGado)
        {
            var result = await this.compraGadoAppService.Save(compraGado);
            if (result == null)
            {
                return Response(this.compraGadoAppService.ApplicationErrors);
            }
            return Response(result);
        }
    }
}
