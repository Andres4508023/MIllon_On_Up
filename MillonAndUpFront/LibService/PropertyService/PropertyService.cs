using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DomainBD.Domain;
using DomainBD.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LibService.PropertyService
{
    public class PropertyService : IPropertyService
    {
        private readonly AppSetting _appSetting;
        public PropertyService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }
        public async Task<List<PropertyModel>> GetPropertiesList()
        {
            var ProperiesList = new List<PropertyModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/Property/GePropertyList");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    ProperiesList = JsonConvert.DeserializeObject<List<PropertyModel>>(readTask);
                    return ProperiesList;
                }
            }
            return ProperiesList;
        }
        public async Task<List<Property>> GetPropertiesId(int IdPropery)
        {
            var ProperiesList = new List<Property>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/Property?IdProperty=" + IdPropery);
                
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    ProperiesList = JsonConvert.DeserializeObject<List<Property>>(readTask);
                    return ProperiesList;
                }
            }
            return ProperiesList;
        }       
        public async Task<bool> SaveProperty(PropertyModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/Property/CreateProperty", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }
        public async Task<bool> UpdateProperty(PropertyModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/Property/UpdateProperty", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }
        public async Task<bool> DeleteProperty(int IdProperty)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(IdProperty);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
            //    var response = await client.DeleteAsync("/api/Property/" + content);

                var response = await client.DeleteAsync("/api/Property?IdProperty=" + IdProperty);
                //  https://localhost:44313/api/Property?Idproperty=10
                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }


    }
}
