
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
    public static class CompraGadoItemServices
    {
        private static string _urlAPI = ConfigurationManager.AppSettings["UrlAPI"].ToString();
        public static async Task<List<CompraGadoItem>> GetAll()
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGadoItem/get-compragadoitem-listagem");
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var compraGadoItemJsonString = await response.Content.ReadAsStringAsync();
                        var compraGadoItemString = JObject.Parse(compraGadoItemJsonString);
                        var responseData = JObject.Parse(compraGadoItemString.GetValue("data").ToString());
                        var objectData = responseData.GetValue("data");

                        if (objectData == null)
                        {
                            return null;
                        }

                        var compraGadosItem = JsonConvert.DeserializeObject<CompraGadoItem[]>(objectData.ToString());
                        return compraGadosItem == null ? null : compraGadosItem.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o CompraGadoItem : " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task<CompraGadoItem> GetById(int id)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGadoItem?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var compraGadoItemJsonString = await response.Content.ReadAsStringAsync();
                        var compraGadoItem= JsonConvert.DeserializeObject<CompraGadoItem>(compraGadoItemJsonString);
                        return compraGadoItem;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o CompraGadoItem: " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task Save(CompraGadoItem compraGadoItem)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGadoItem");
            using (var client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(compraGadoItem);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                if (!result.IsSuccessStatusCode)
                    throw new Exception("Erro ao gravar o CompraGadoItem: " + result.ReasonPhrase);
            }
        }
        public static async Task Delete(int id)
        {
            Uri URI = new Uri(_urlAPI + "/api/CompraGadoItem?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(URI))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Não foi possível obter o CompraGadoItem: " + response.StatusCode);
                    }

                }
            }
        }
    }
}
