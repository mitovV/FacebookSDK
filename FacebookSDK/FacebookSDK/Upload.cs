namespace FacebookSDK
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Facebook;

    using static Common.GlobalConstants.Upload;

    public class Upload
    {
        private readonly FacebookClient facebookClient;

        public Upload(string accessToken)
         => this.facebookClient = new FacebookClient(accessToken);


        public async Task<IDictionary<string, object>> UploadPictureToWallAsync(string id, string pictureUrl, string message)
         => (IDictionary<string, object>)await facebookClient
                .PostTaskAsync(id + PhotoPost, new Dictionary<string, object>
                                   {
                                       { UrlPost, pictureUrl },
                                       { MessagePost, message }
                                   });


        public async Task<IDictionary<string, object>> UploadPostToWallAsync(string id, string text)
         => (IDictionary<string, object>)await facebookClient
                .PostTaskAsync(id + FeedPost, new Dictionary<string, object>
                                   {
                                       { MessagePost, text }
                                   });
    }
}
