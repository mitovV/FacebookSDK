﻿namespace FacebookSDK
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using DataParser;
    using UploadPictureProject;

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
            try
            {
                while (true)
                {
                    var post = await parser.GetDataAsync(baseUrl);

                    if (post != null)
                    {
                        var message = $"{post.Title}\nЦена: {post.Price}\n{post.Office}\nДетайли: ⬇⬇⬇⬇⬇⬇\n{post.ProductDetailsLink}";

                        var result = await upload.UploadPictureToWallAsync(id, post.PictureUrl, message);

                        var postId = (string)result["id"];

                        Console.WriteLine($"Post Id: {postId}");

                        Console.WriteLine($"Json: {result}");
                        Console.WriteLine($"Time: {DateTime.Now}");
                    }

                    Thread.Sleep(5000);
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText("exception.txt", ex.Message);
                Console.WriteLine(ex.Message);
                Startup.Main();
            }
        }
    }
}
