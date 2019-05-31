namespace YoLlegoApp.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using YoLlegoApp.Models;

    public class ApiActions
    {
        public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.GetAsync(url);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSucess = false,
                        Message = answer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(answer);
                return new Response
                {
                    IsSucess = true,
                    Result = list
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSucess = false,
                    Message = e.Message,
                };

            }
        }

        public async Task<Response> Post<T>(string urlBase, string prefix, string controller, T model)
        {
            try
            {
                var request = JsonConvert.SerializeObject(model);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var url = $"{prefix}{controller}";
                var response = await client.PostAsync(url, content);
                var answer = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSucess = false,
                        Message = answer,
                    };
                }

                var obj = JsonConvert.DeserializeObject<T>(answer);
                return new Response
                {
                    IsSucess = true,
                    Result = obj
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSucess = false,
                    Message = e.Message,
                };
            }
        }
    }
}