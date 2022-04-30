
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
    public static class AnimalServices
    {
        private static string _urlAPI = ConfigurationManager.AppSettings["UrlAPI"].ToString();
        public static async Task<List<Animal>> GetAll()
        {
            Uri URI = new Uri(_urlAPI + "/api/Animal/get-animal-listagem");
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var animaisJsonString = await response.Content.ReadAsStringAsync();
                        var animaisString = JObject.Parse(animaisJsonString);
                        var responseData = JObject.Parse(animaisString.GetValue("data").ToString());
                        var objectData = responseData.GetValue("data");

                        if (objectData == null)
                            return null;

                        var animais = JsonConvert.DeserializeObject<Animal[]>(objectData.ToString());
                        return animais == null ? null : animais.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o animal : " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task<Animal> GetById(long id)
        {
            Uri URI = new Uri(_urlAPI + "/api/Animal?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(URI))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var animalJsonString = await response.Content.ReadAsStringAsync();
                        var animal = JsonConvert.DeserializeObject<Animal>(animalJsonString);
                        return animal;
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível obter o animal: " + response.StatusCode);
                    }
                    return null;
                }
            }
        }
        public static async Task Save(Animal animal)
        {
            Uri URI = new Uri(_urlAPI + "/api/Animal");
            using (var client = new HttpClient())
            {
                var serialized = JsonConvert.SerializeObject(animal);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(URI, content);

                if (!result.IsSuccessStatusCode)
                    throw new Exception("Erro ao gravar Animal: " + result.ReasonPhrase);
            }
        }
        public static async Task Delete(int id)
        {
            Uri URI = new Uri(_urlAPI + "/api/Animal?id=" + id);
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync(URI))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Não foi possível excluir o animal: " + response.StatusCode);
                    }

                }
            }
        }
    }
}
