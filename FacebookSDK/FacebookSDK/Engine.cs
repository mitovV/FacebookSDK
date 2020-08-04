namespace FacebookSDK
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using DataParser;

    public class Engine
    {
        private readonly string baseUrl;
        private readonly Parser parser;
        private readonly Upload upload;
        private readonly string id;

        public Engine(string baseUrl, Parser parser, Upload upload, string id)
        {
            this.baseUrl = baseUrl;
            this.parser = parser;
            this.upload = upload;
            this.id = id;
        }

        public async Task RunAsync()
        {
            while (true)
            {
                Thread
                        .Sleep(5000);

                try
                {
                    var post = await parser
                        .GetDataAsync(baseUrl);

                    if (post != null)
                    {
                        if (post.PictureUrl is null || post.ProductDetailsLink is null)
                        {
                            continue;
                        }

                        var message = $"{post.Title}\nЦена: {post.Price}\n{post.Office}\nДетайли: ⬇⬇⬇⬇⬇⬇\n{post.ProductDetailsLink}";

                        var result = await upload
                            .UploadPictureToWallAsync(id, post.PictureUrl, message);

                        var postId = (string)result["id"];

                        Console.WriteLine($"Post Id: {postId}");

                        Console.WriteLine($"Json: {result}");
                        Console.WriteLine($"Time: {DateTime.Now}");

                       await File
                            .WriteAllTextAsync("lastPostLink.txt", post.ProductDetailsLink);
                    }
                }
                catch (Exception ex)
                {
                    await File
                        .WriteAllTextAsync("exception.txt", $"{ex.Message}\n{ex.StackTrace}\n{DateTime.Now}");

                    Console.WriteLine(ex.Message);

                    continue;
                }
            }
        }
    }
}
