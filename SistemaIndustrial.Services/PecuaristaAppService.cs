using SistemaIndustrial.Domain.Entities;
using SistemaIndustrial.Repositories.Context;
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
    public class PecuaristaAppService : AppService
    {
        readonly PecuaristaRepository pecuaristaRepository;
        public PecuaristaAppService(PecuaristaRepository _pecuaristaRepository)
        {
            this.pecuaristaRepository = _pecuaristaRepository;
        }
        public Pecuarista GetById(int Id)
        {
            Pecuarista result = null;
            try
            {
                result = this.pecuaristaRepository.GetById(Id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListagemResponseResult<Pecuarista> GetAll(string query = "", int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                IQueryable<Pecuarista> result;

                result = this.pecuaristaRepository.GetAll().OrderBy(c => c.Nome);

                var totalCount = result.Count();
                if (result != null && totalCount > 0)
                {
                    var data = result.ToList(); 

                    return new ListagemResponseResult<Pecuarista>
                    {
                        Data = data,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Success = true,
                        TotalResult = totalCount
                    };
                }
                return new ListagemResponseResult<Pecuarista> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
            catch (Exception)
            {
                return new ListagemResponseResult<Pecuarista> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
        }
        public async Task<Pecuarista> Save(Pecuarista pecuarista)
        {
            try
            {
                if (string.IsNullOrEmpty(pecuarista.Nome))
                {
                    this.AddErrorApplicationErrors("pecuaristaNullOrEmpty", "O nome está vazio.");
                    return null;
                }

                var result = await pecuaristaRepository.SaveOrUpdateAsync(pecuarista);

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
                pecuaristaRepository.Delete(result);
            }
            return;
        }
    }
}
