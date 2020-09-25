namespace DataParser
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using FacebookSDK.Models;

    using AngleSharp.Html.Parser;

    public class Parser
    {
        private readonly IHtmlParser htmlParser;
        private readonly HttpClient httpClient;

        public Parser(IHtmlParser parser, HttpClient httpClient)
        {
            this.htmlParser = parser;
            this.httpClient = httpClient;

            this.httpClient
              .DefaultRequestHeaders
              .Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:79.0) Gecko/20100101 Firefox/79.0");
        }

        public async Task<PostDTO> GetDataAsync(string baseUrl)
        {
            var html = await httpClient
                .GetStringAsync(baseUrl);

            var document = await htmlParser
                .ParseDocumentAsync(html);

            var element = document
                .QuerySelector("div[class='moduletable'] div[class='vmgroup'] ul li");

            var productDetailsLink = baseUrl + element
                .FirstElementChild
                .Attributes["href"]
                .Value
                .Trim();

            var lastPostLink = File
                .ReadAllText("lastPostLink.txt");

            if (lastPostLink == productDetailsLink)
            {
                return null;
            }

            var productPage = await httpClient
                .GetStringAsync(productDetailsLink);

            var productPageDocument = await htmlParser
                .ParseDocumentAsync(productPage);

            var office = productPageDocument
                .QuerySelector("div[class='productdetails-view productdetails'] div[class='manufacturer']")
                .TextContent
                .Trim();

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

            return new PostDTO
            {
                ProductDetailsLink = productDetailsLink,
                PictureUrl = pictureUrl,
                Title = title,
                Price = price,
                Office = office
            };
        }
    }
}
