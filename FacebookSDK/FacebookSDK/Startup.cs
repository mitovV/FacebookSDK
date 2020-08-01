namespace FacebookSDK
{
    using System.IO;

    using DataParser;
    using UploadPictureProject;

    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var baseUrl = "http://vtora-upotreba.org/";

            var settings = File.ReadAllText("settings.json");
            var facebookSettings = JsonConvert.DeserializeObject<FacebookSettings>(settings);

            var id = facebookSettings.FacebookAccess.Id;
            var accessToken = facebookSettings.FacebookAccess.AccessToken;

            var parser = new Parser();
            var upload = new Upload(accessToken);

            var engine = new Engine(baseUrl, parser, upload, id);

            engine
                .RunAsync()
                .GetAwaiter()
                .GetResult();
        }
    }
}
