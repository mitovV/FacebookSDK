namespace FacebookSDK.DataParser
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    using FacebookSDK.Models;

    using AngleSharp.Html.Parser;

    using static FacebookSDK.Common.GlobalConstants.Parser;

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
              .Add(RequestHeaderName, RequestHeaderValue);
        }

        public async Task<PostDTO> GetDataAsync(string baseUrl)
        {
            var html = await httpClient
                .GetStringAsync(baseUrl);

            var document = await htmlParser
                .ParseDocumentAsync(html);

            var element = document
                .QuerySelector(ElementSelector);

            var productDetailsLink = baseUrl + element
                .FirstElementChild
                .Attributes[DetailsLinkAttributeName]
                .Value
                .Trim();

            var lastPostLink = File
                .ReadAllText(Common.GlobalConstants.LastPostLinkFileName);

            if (lastPostLink == productDetailsLink)
            {
                return null;
            }

            var productPage = await httpClient
                .GetStringAsync(productDetailsLink);

            var productPageDocument = await htmlParser
                .ParseDocumentAsync(productPage);

            var office = productPageDocument
                .QuerySelector(OfficeSelector)
                .TextContent
                .Trim();

            var pictureUrl = baseUrl + element
                .FirstElementChild
                .QuerySelector(PictureUrlSelector)
                .Attributes[PictureUrlAttributeName]
                .Value;

            var title = element
                .QuerySelector(TitleSelector)
                .NextElementSibling
                .InnerHtml;

            var price = document
                .QuerySelector(PriceSelector)
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
