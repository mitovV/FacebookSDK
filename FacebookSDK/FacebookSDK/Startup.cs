namespace FacebookSDK
{
    using System.IO;
    using System.Threading;

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

            while (true)
            {
                var post = parser.GetData(baseUrl);

                if (post != null)
                {
                    var message = $"{post.Title}\nЦена: {post.Price}\nДетайли: ⬇⬇⬇⬇⬇⬇\n{post.ProductDetailsLink}";

                    var upload = new Upload(accessToken);

                    upload.UploadPictureToWall(id, post.PictureUrl, message);
                }

                Thread.Sleep(5000);
            }
        }
    }
}
