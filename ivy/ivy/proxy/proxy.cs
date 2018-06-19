using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ivy.proxy
{
    public class proxy
    {
        public static async Task<T> get<T>(string url)
        {
            HttpClient client = new HttpClient();
            string value = await client.GetStringAsync(url);
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            return result;
        }

        public static async Task<T> post<T>(string url, object inValue)
        {
            HttpClient client = new HttpClient();
            string strvalue = Newtonsoft.Json.JsonConvert.SerializeObject(inValue);
            var content = new StringContent(strvalue, Encoding.UTF8, "application/json");
            var uri = new Uri(url);
            HttpResponseMessage response = null;
            try
            {
                response = await client.PostAsync(uri, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception("Erro ao executar serviço.");

            //string value = await response.Content.ReadAsStringAsync();
            T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            return result;
        }

    }
}
