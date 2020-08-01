namespace UploadPictureProject
{
    using System;
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

        public async Task UploadPictureToWall(string id, string pictureUrl, string message)
        {
            var result = (IDictionary<string, object>)await facebookClient.PostTaskAsync(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "url", pictureUrl },
                                       { "message",$"{message}" }
                                   });

            var postId = (string)result["id"];

            Console.WriteLine($"Post Id: {postId}");

            Console.WriteLine($"Json: {result}");
            Console.WriteLine($"Time: {DateTime.Now}");
        }

        public async Task UploadPostToWall(string id, string text)
        {
            var result = (IDictionary<string, object>)await facebookClient.PostTaskAsync(id + "/feed", new Dictionary<string, object>
                                   {
                                       { "message",$"{text}" }
                                   });

            var postId = (string)result["id"];

            Console.WriteLine($"Post Id: {postId}");

            Console.WriteLine($"Json: {result}");
            Console.WriteLine($"Time: {DateTime.Now}");
        }
    }
}