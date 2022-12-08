using Newtonsoft.Json;
using SrtTranslator.Models;
using System.Reflection;
using System.Text;

namespace SrtTranslator
{
    public class OpenAiSimpleTask
    {
        private string OpenAiApiKey = "";
        private string OpenAiOrg = "";
        private string OpenAiPath = "https://api.openai.com/v1/completions";
        private string OpenAiModel = "";
        private int OpenAiMaxToken = 256;
        private float OpenAiTemperature = 0.4f;
        private string Delimiter = "\r\n";
        readonly HttpClient client = new HttpClient();
        private new readonly RequestModel Model = new RequestModel();
        public OpenAiSimpleTask(string openAiApiKey = "", string openAiOrg = "", string openAiPath = "", string openAiModel
            = "", int openAiMaxToken = 0, float openAiTemperature = 1)
        {
            OpenAiApiKey = openAiApiKey;
            OpenAiOrg = openAiOrg;
            OpenAiPath = openAiPath;
            OpenAiModel = openAiModel;
            OpenAiMaxToken = openAiMaxToken;
            OpenAiTemperature = openAiTemperature;
        }

        public OpenAiSimpleTask SetOpenAiApiKey(string key)
        {
            this.OpenAiApiKey = key;
            return this;
        }
        public OpenAiSimpleTask SetOpenAiOrg(string org)
        {
            this.OpenAiOrg = org;
            return this;
        }
        public OpenAiSimpleTask SetOpenAiPath(string path)
        {
            this.OpenAiPath = path;
            return this;
        }
        public OpenAiSimpleTask SetOpenAiModel(string model)
        {
            this.OpenAiModel = model;
            return this;
        }
        public OpenAiSimpleTask SetOpenAiMaxToken(int token)
        {
            this.OpenAiMaxToken = token;
            return this;
        }
        public OpenAiSimpleTask SetOpenAiTemperature(float temp)
        {
            this.OpenAiTemperature = temp;
            return this;
        }

        public Task<string> Translate(string szoveg)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", $"{this.OpenAiApiKey}");
            var a = FormatPostDataAsync(szoveg);
            var b = client.PostAsync(this.OpenAiPath, a);
            using var res = b.Result;
            string result = res.Content.ReadAsStringAsync().Result;
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
            var end_res = myDeserializedClass.choices[0].text.Replace("\n", this.Delimiter);
            return Task.FromResult(end_res);
        }

        private HttpContent FormatPostDataAsync(string prompt)
        {
            Model.model = this.OpenAiModel;
            Model.prompt = new string[] { prompt };
            Model.max_tokens = this.OpenAiMaxToken;
            Model.temperature = this.OpenAiTemperature;
            var sm = JsonConvert.SerializeObject(Model);
            var httpcontent = new StringContent(sm, Encoding.UTF8, "application/json");
            return httpcontent;
        }
    }
    
}