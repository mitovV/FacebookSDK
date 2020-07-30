namespace UploadPictureProject
{
    using System;
    using System.Collections.Generic;

    using Facebook;

    public class Upload
    {
        private readonly FacebookClient facebookClient;

        public Upload(string accessToken)
        {
            this.facebookClient = new FacebookClient(accessToken);
        }

        public void UploadPictureToWall(string id, string pictureUrl, string message)
        {
            try
            {
                var result = (IDictionary<string, object>)facebookClient.Post(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "url", pictureUrl },
                                       { "message",$"{message}" }
                                   });

                var postId = (string)result["id"];

                Console.WriteLine($"Post Id: {postId}");

                Console.WriteLine($"Json: {result}");
                Console.WriteLine($"Time: {DateTime.Now}");

            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                throw ex;
            }
        }

        public void UploadPostToWall(string id, string text)
        {
            try
            {
                var result = (IDictionary<string, object>)facebookClient.Post(id + "/feed", new Dictionary<string, object>
                                   {
                                       { "message",$"{text}" }
                                   });

                var postId = (string)result["id"];

                Console.WriteLine("Post Id: {0}", postId);

                Console.WriteLine("Json: {0}", result.ToString());

            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                throw ex;
            }
        }
    }
}
