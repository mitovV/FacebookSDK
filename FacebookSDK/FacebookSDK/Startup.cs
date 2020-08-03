namespace FacebookSDK
{
    using System.IO;
    using System.Net.Http;

    using DataParser;

    using AngleSharp.Html.Parser;
    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var baseUrl = "http://vtora-upotreba.org/";

            var settings = File
                .ReadAllText("settings.json");

            var facebookSettings = JsonConvert
                .DeserializeObject<FacebookSettings>(settings);

            var id = facebookSettings
                .FacebookAccess
                .Id;

            var accessToken = facebookSettings
                .FacebookAccess
                .AccessToken;

            var htmlParser = new HtmlParser();
            var httpClient = new HttpClient();

            var parser = new Parser(htmlParser, httpClient);
            var upload = new Upload(accessToken);

            var engine = new Engine(baseUrl, parser, upload, id);

            engine
                .RunAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}
