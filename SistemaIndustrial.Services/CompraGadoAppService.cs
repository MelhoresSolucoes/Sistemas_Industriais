using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Repositories.Repository;
using SistemaIndustrial.Services.Base;
using SistemaIndustrial.Services.ViewModels.ResponseResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.Services
{
    public class CompraGadoAppService : AppService
    { 
        readonly CompraGadoRepository compraGadoRepository;
        public CompraGadoAppService(CompraGadoRepository _compraGadoRepository)
        {
            this.compraGadoRepository = _compraGadoRepository;
        }
        public CompraGado GetById(int id)
        {
            CompraGado result = null;
            try
            {
                result = this.compraGadoRepository.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListagemResponseResult<CompraGado> GetAll(string query = "", int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                IQueryable<CompraGado> result;

                result = this.compraGadoRepository.GetAllWithOthersEntities().OrderByDescending(c => c.Id);

                var totalCount = result.Count();
                if (result != null && totalCount > 0)
                {
                    var data = result.ToList();

                    return new ListagemResponseResult<CompraGado>
                    {
                        Data = data,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Success = true,
                        TotalResult = totalCount
                    };
                }
                return new ListagemResponseResult<CompraGado> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
            catch (Exception)
            {
                return new ListagemResponseResult<CompraGado> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
        }
        public async Task<CompraGado> Save(CompraGado compraGado)
        {
            try
            {
                DateTime dataEntrega;
                if ( ! DateTime.TryParse(compraGado.DataEntrega.ToShortDateString(),out dataEntrega))
                {
                    this.AddErrorApplicationErrors("Data Inválida", "Informe uma data correta");
                    return null;
                }
                
                var result = await compraGadoRepository.SaveOrUpdateAsync(compraGado);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
