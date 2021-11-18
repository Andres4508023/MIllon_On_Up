using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DomainBD.Domain;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace LibService.OwnerService
{
    public class OwnerService : IOwnerService
    {
        private readonly AppSetting _appSetting;

        public OwnerService(IOptions<AppSetting> appSetting)
        {
            _appSetting = appSetting.Value;
        }

       
        public async Task<List<Owner>> GetOwnersList()
        {
            var OwnerList = new List<Owner>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/Owner/GetOwner");

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    OwnerList = JsonConvert.DeserializeObject<List<Owner>>(readTask);
                    return OwnerList;
                }
            }
            return OwnerList;
        }
        public async Task<List<Owner>> GetOwnersListId(int IdOwner)
        {
            var OwnerList = new List<Owner>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("/api/Owner/GetOwnerId?IdOwner=" + IdOwner);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    OwnerList = JsonConvert.DeserializeObject<List<Owner>>(readTask);
                    return OwnerList;
                }
            }
            return OwnerList;
        }
        public async Task<bool> SaveOwner(Owner model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/Owner/AddOwner", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }
        public async Task<bool> UpdateOwner(Owner model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.PutAsync("/api/Owner/UpdateOwner", content);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<bool>(readTask);

                    return result;
                }
            }
            return false;
        }
        public async Task<bool> DeleteOwner(int IdOwner)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_appSetting.WebAPILink);
                client.DefaultRequestHeaders.Clear();
                string jsonData = JsonConvert.SerializeObject(IdOwner);
                var content = new StringContent(jsonData, UnicodeEncoding.UTF8, "application/json");
                var response = await client.DeleteAsync("/api/Owner?IdOwner=" + IdOwner);

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
