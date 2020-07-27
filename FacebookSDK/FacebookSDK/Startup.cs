namespace FacebookSDK
{
    using System.IO;
    using System.Threading.Tasks;

    using UploadPictureProject;

    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var settings = File.ReadAllText("settings.json");
            var facebookSettings = JsonConvert.DeserializeObject<FacebookSettings>(settings);

            var id = facebookSettings.FacebookAccess.Id;
            var accessToken = facebookSettings.FacebookAccess.AccessToken;
            var pictureUrl = @"http://vtora-upotreba.org/images/stories/virtuemart/product/501177_1014487_1.jpg";

            var upload = new Upload(accessToken);

            upload.UploadPictureToWall(id, pictureUrl, "Test \n new row");
        }
    }
}
