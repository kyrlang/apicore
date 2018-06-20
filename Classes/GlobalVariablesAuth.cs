using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aula02.Classes
{
    public static class GlobalVariablesAuth
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalVariablesAuth()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:52481/api/v1/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}