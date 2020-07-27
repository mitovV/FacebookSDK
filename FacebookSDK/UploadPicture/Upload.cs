namespace UploadPictureProject
{
    using System;
    using System.Collections.Generic;

    using Facebook;

    public static class Upload
    {
        public static void UploadPictureToWall(string id, string accessToken, string pictureUrl, string message)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post(id + "/photos", new Dictionary<string, object>
                                   {
                                       { "url", pictureUrl },
                                       { "message",$"{message}" }
                                   });

                var postId = (string)result["id"];

                Console.WriteLine("Post Id: {0}", postId);

                Console.WriteLine("Json: {0}", result.ToString());

            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void UploadPostToWall(string id, string accessToken, object text)
        {
            try
            {
                var fb = new FacebookClient(accessToken);

                var result = (IDictionary<string, object>)fb.Post(id + "/feed", new Dictionary<string, object>
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
                throw;
            }
        }
    }
}
