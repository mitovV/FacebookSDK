namespace FacebookSDK
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

        public void Run()
        {
            try
            {
                Task.Run(() =>
                {
                    while (true)
                    {
                        var post = parser.GetData(baseUrl);

                        if (post != null)
                        {
                            var message = $"{post.Title}\nЦена: {post.Price}\n{post.Office}\nДетайли: ⬇⬇⬇⬇⬇⬇\n{post.ProductDetailsLink}";


                            upload.UploadPictureToWall(id, post.PictureUrl, message);
                        }

                        Thread.Sleep(5000);
                    }
                }).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                File.WriteAllText("exception.txt", ex.Message);
                Startup.Main();
            }
        }
    }
}
