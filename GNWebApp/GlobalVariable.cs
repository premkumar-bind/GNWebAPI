using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
namespace GNWebApp
{
    public static class GlobalVariable
    {
        public static HttpClient WebApiClient = new HttpClient();
       static GlobalVariable()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44364/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         

        }
    }
}