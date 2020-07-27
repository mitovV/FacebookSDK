namespace FacebookSDK
{
    using System.IO;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    public class Startup
    {
        public static void Main()
        {
            var facebookClient = new FacebookClient();
            var facebookService = new FacebookService(facebookClient);

            var settings = File.ReadAllText("settings.json");
            var facebookSettings = JsonConvert.DeserializeObject<FacebookSettings>(settings);

            var accessToken = facebookSettings.FacebookAccess.AccessToken;

            var postOnWallTask = facebookService.PostOnWallAsync(accessToken, "Test");

            Task.WaitAll(postOnWallTask);
        }
    }
}
