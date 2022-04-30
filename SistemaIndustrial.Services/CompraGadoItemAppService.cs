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
    public class CompraGadoItemAppService : AppService
    { 
        readonly CompraGadoItemRepository compraGadoItemRepository;
        public CompraGadoItemAppService(CompraGadoItemRepository _compraGadoItemRepository)
        {
            this.compraGadoItemRepository = _compraGadoItemRepository;
        }
        public CompraGadoItem GetById(int id)
        {
            CompraGadoItem result = null;
            try
            {
                result = this.compraGadoItemRepository.GetById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListagemResponseResult<CompraGadoItem> GetAll(string query = "", int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                IQueryable<CompraGadoItem> result;

                result = this.compraGadoItemRepository.GetAllWithOthersEntities().OrderByDescending(c => c.Id);

                var totalCount = result.Count();
                if (result != null && totalCount > 0)
                {
                    var data = result.ToList();

                    return new ListagemResponseResult<CompraGadoItem>
                    {
                        Data = data,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Success = true,
                        TotalResult = totalCount
                    };
                }
                return new ListagemResponseResult<CompraGadoItem> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
            catch (Exception)
            {
                return new ListagemResponseResult<CompraGadoItem> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
        }
        public async Task<CompraGadoItem> Save(CompraGadoItem compraGadoItem)
        {
            try
            {
                if (  compraGadoItem.Quantidade <1)
                {
                    this.AddErrorApplicationErrors("Quantidade Inválida", "A quantidade de gado deve ser maior que ZERO");
                    return null;
                }
                
                var result = await compraGadoItemRepository.SaveOrUpdateAsync(compraGadoItem);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            var result = GetById(id);

            if (result != null)
            {
                compraGadoItemRepository.Delete(result);
            }
            return;
        }
    }
}
