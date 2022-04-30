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
    public class AnimalAppService : AppService
    {
        readonly AnimalRepository animalRepository;
        public AnimalAppService(AnimalRepository _animalRepository)
        {
            this.animalRepository = _animalRepository;
        }
        public Animal GetById(int Id)
        {
            Animal result = null;
            try
            {
                result = this.animalRepository.GetById(Id);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ListagemResponseResult<Animal> GetAll(string query = "", int pageSize = 10, int pageIndex = 0)
        {
            try
            {
                IQueryable<Animal> result;

                result = this.animalRepository.GetAll().OrderByDescending(c => c.Id);

                var totalCount = result.Count();
                if (result != null && totalCount > 0)
                {
                    var data = result.ToList();

                    return new ListagemResponseResult<Animal>
                    {
                        Data = data,
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Success = true,
                        TotalResult = totalCount
                    };
                }
                return new ListagemResponseResult<Animal> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
            catch (Exception)
            {
                return new ListagemResponseResult<Animal> { Data = null, Success = false, PageIndex = pageIndex, PageSize = pageSize, TotalResult = 0 };
            }
        }
        public async Task<Animal> Save(Animal animal)
        {
            try
            {
                if (string.IsNullOrEmpty(animal.Descricao))
                {
                    this.AddErrorApplicationErrors("pecuaristaNullOrEmpty", "O nome está vazio.");
                    return null;
                }

                var result = await animalRepository.SaveOrUpdateAsync(animal);

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
                animalRepository.Delete(result);
            }
            return;
        }

    }
}
