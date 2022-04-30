
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
    public static class PecuaristaServices
    {
        private static string _urlAPI = ConfigurationManager.AppSettings["UrlAPI"].ToString();
        public static async Task<List<Pecuarista>> GetAll()
        {
            Uri URI = new Uri(_urlAPI + "/api/Pecuarista/get-pecuarista-listagem");
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var pecuaristaJsonString = await response.Content.ReadAsStringAsync();
                        var pecuaristaString = JObject.Parse(pecuaristaJsonString);
                        var responseData = JObject.Parse(pecuaristaString.GetValue("data").ToString());
                        var objectData = responseData.GetValue("data");

                        if (objectData == null)
                        {
                            return null;
                        }

                        var pecuaristas = JsonConvert.DeserializeObject<Pecuarista[]>(objectData.ToString());
                        return pecuaristas ==null ? null :  pecuaristas.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o pecuarista : " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task<Pecuarista> GetById(long id)
        {
            Uri URI = new Uri(_urlAPI + "/api/Pecuarista?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var PecuaristaJsonString = await response.Content.ReadAsStringAsync();
                        var pecuarista = JsonConvert.DeserializeObject<Pecuarista>(PecuaristaJsonString);
                        return pecuarista;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o pecuarista: " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task Save(Pecuarista pecuarista)
        {
            Uri URI = new Uri(_urlAPI + "/api/Pecuarista");
            using (var client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(pecuarista);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                if (!result.IsSuccessStatusCode)
                    throw new Exception("Erro ao gravar o Pecuarista: " + result.ReasonPhrase);
            }
        }
        public static async Task Delete(int id)
        {
            Uri URI = new Uri(_urlAPI + "/api/Pecuarista?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(URI))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Não foi possível obter o pecuarista: " + response.StatusCode);
                    }

                }
            }
        }
    }
}
