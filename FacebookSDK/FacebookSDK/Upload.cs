namespace UploadPictureProject
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Facebook;

    public class Upload
    {
        private readonly FacebookClient facebookClient;

        public Upload(string accessToken)
        {
            this.facebookClient = new FacebookClient(accessToken);
        }

        public async Task<IDictionary<string, object>> UploadPictureToWallAsync(string id, string pictureUrl, string message)
        {
            var result = (IDictionary<string, object>)await facebookClient
                .PostTaskAsync(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "url", pictureUrl },
                                       { "message",$"{message}" }
                                   });

            return result;
        }

        public async Task<IDictionary<string, object>> UploadPostToWallAsync(string id, string text)
        {
            var result = (IDictionary<string, object>)await facebookClient
                .PostTaskAsync(id + "/feed", new Dictionary<string, object>
                                   {
                                       { "message",$"{text}" }
                                   });

            return result;
        }
    }
}