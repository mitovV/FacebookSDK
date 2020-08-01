namespace DataParser
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using AngleSharp.Html.Parser;

    public class Parser
    {
        public async Task<PostDTO> GetDataAsync(string baseUrl)
        {
            var parser = new HtmlParser();
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
                .Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:79.0) Gecko/20100101 Firefox/79.0");

            var html = await httpClient
                .GetStringAsync(baseUrl);

            var document = await parser
                .ParseDocumentAsync(html);

            var element = document
                .QuerySelector("div[class='moduletable'] div[class='vmgroup'] ul li");

            var productDetailsLink = baseUrl + element
                .FirstElementChild
                .Attributes["href"]
                .Value
                .Trim();

            var lastPostLink = File.ReadAllText("lastPostLink.txt");

            if (lastPostLink == productDetailsLink)
            {
                return null;
            }

            var productPage = await httpClient
                .GetStringAsync(productDetailsLink);

            var productPageDocument = await parser
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

            File.WriteAllText("lastPostLink.txt", productDetailsLink);

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
