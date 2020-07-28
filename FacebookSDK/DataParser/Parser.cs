namespace DataParser
{
    using System.Net.Http;

    using AngleSharp.Html.Parser;

    public class Parser
    {
        private string lastPostLink;

        public PostDTO GetData(string baseUrl)
        {
            var parser = new HtmlParser();
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                .Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:79.0) Gecko/20100101 Firefox/79.0");

            var html = httpClient
                .GetStringAsync(baseUrl)
                .GetAwaiter()
                .GetResult();

            var document = parser
                .ParseDocument(html);

            var element = document
                .QuerySelector("div[class='moduletable'] div[class='vmgroup'] ul li");

            var productDetailsLink = baseUrl + element
                .FirstElementChild
                .Attributes["href"]
                .Value
                .Trim();

            if (lastPostLink == productDetailsLink)
            {
                return null;
            }

            var pictureUrl = baseUrl + element
                .FirstElementChild
                .QuerySelector("img")
                .Attributes["src"]
                .Value;

            var title = element
                .QuerySelector("div[class='clear']")
                .NextElementSibling
                .InnerHtml;

            var price = document
                .QuerySelector("div[class='moduletable'] div[class='vmgroup'] div[class='product-price'] div [class='PricesalesPrice']")
                .InnerHtml;

            lastPostLink = productDetailsLink;

            return new PostDTO
            {
                ProductDetailsLink = productDetailsLink,
                PictureUrl = pictureUrl,
                Title = title,
                Price = price
            };
        }
    }
}
