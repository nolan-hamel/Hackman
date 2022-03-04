using System.Net.Http.Headers;

namespace Hackman
{
    class Api
    {
        private async Task<string> SendRequest()
        {
            string word = "";
            string url = $"https://www.clemsonhackman.com/api/word";
            string key = $"?key="+File.ReadAllText(@"C:\Users\nolan\Desktop\Sophia\personal_projects\Hackman\Hackman\key.txt");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(key).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                word = await response.Content.ReadAsStringAsync();
            }
            else
            {
                word = null;
            }
            return word;
        }

        public string GetWord()
        {
            string jsonStr = SendRequest().GetAwaiter().GetResult();
            if(jsonStr == null) { return null; }
            string[] jsonList = jsonStr.Split("\"");
            return jsonList[3];
        }
    }
}