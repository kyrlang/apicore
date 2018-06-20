using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Aula02.Classes
{
    public static class GlobalVariablesTrans
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalVariablesTrans()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:54824/api/v1/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}