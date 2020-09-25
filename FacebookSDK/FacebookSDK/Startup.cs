namespace FacebookSDK
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text;

    using DataParser;

    using AngleSharp.Html.Parser;
    using Newtonsoft.Json;

    using static Common.GlobalConstants.Startup;

    public class Startup
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var settings = File
                .ReadAllText(FileName);

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

            var engine = new Engine(Url, parser, upload, id);

            engine
                .RunAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}
