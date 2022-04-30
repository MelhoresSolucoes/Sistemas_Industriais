
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaIndustrial.View.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaIndustrial.View.Services
{
    public static class CompraGadoServices
    {
        private static string _urlAPI = ConfigurationManager.AppSettings["UrlAPI"].ToString();
        public static async Task<List<CompraGado>> GetAll()
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGado/get-compragado-listagem");
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var compraGadoJsonString = await response.Content.ReadAsStringAsync();
                        var compraGadoString = JObject.Parse(compraGadoJsonString);
                        var responseData = JObject.Parse(compraGadoString.GetValue("data").ToString());
                        var objectData = responseData.GetValue("data");

                        if (objectData == null)
                        {
                            return null;
                        }

                        var compraGados = JsonConvert.DeserializeObject<CompraGado[]>(objectData.ToString());
                        return compraGados == null ? null : compraGados.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o CompraGado : " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task<CompraGado> GetById(long id)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGado?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var compraGadoJsonString = await response.Content.ReadAsStringAsync();
                        var compraGado = JsonConvert.DeserializeObject<CompraGado>(compraGadoJsonString);
                        return compraGado;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o pecuarista: " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task<CompraGado> Save(CompraGado compraGado)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGado");
            using (var client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(compraGado);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                if (!result.IsSuccessStatusCode)
                    throw new Exception("Erro ao gravar o CompraGado: " + result.ReasonPhrase);


                var responseContent = await result.Content.ReadAsStringAsync();
                var compraGadoResult = JsonConvert.DeserializeObject<CustomResponse<CompraGado>>(responseContent);

                return compraGadoResult.data;
            }
        }
        public static async Task Delete(int id)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGado?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(URI))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Não foi possível obter o CompraGado: " + response.StatusCode);
                    }

                }
            }
        }
    }
}
