namespace UploadPictureProject
{
    using System;
    using System.Collections.Generic;

    using Facebook;

    public static class UploadPicture
    {
        public static string UploadPictureToWall(string id, string accessToken, string pictureUrl, string message)
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

                return postId;
            }
            catch (FacebookApiException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
