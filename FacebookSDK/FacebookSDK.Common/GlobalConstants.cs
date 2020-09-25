namespace FacebookSDK.Common
{
    public static class GlobalConstants
    {
        public const string LastPostLinkFileName = "lastPostLink.txt";

        public class Startup
        {
            public const string Url = "http://vtora-upotreba.org/";
            public const string FileName = "settings.json";
        }

        public class Upload
        {
            public const string PhotoPost = "/photos";
            public const string FeedPost = "/feed";
            public const string UrlPost = "url";
            public const string MessagePost = "message";
        }

        public class Engine
        {
            public const int SleepingTime = 5000;
            public const string Message = "🛒 {0}\n💴 Цена: {1}\n🌎 {2}\n‼ Детайли: ⬇⬇⬇⬇\n✅ {3}";
            public const string PostId = "Post Id:";
            public const string ResultId = "id";
            public const string Json = "Json:";
            public const string Time = "Time:";
            public const string ExeptonFileName = "exception.txt";
        }

        public class Parser
        {
            public const string RequestHeaderName = "User-Agent";
            public const string RequestHeaderValue = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:79.0) Gecko/20100101 Firefox/79.0";
            public const string ElementSelector = "div[class='moduletable'] div[class='vmgroup'] ul li";
            public const string DetailsLinkAttributeName = "href";
            public const string OfficeSelector = "div[class='productdetails-view productdetails'] div[class='manufacturer']";
            public const string PictureUrlSelector = "img";
            public const string PictureUrlAttributeName = "src";
            public const string TitleSelector = "div[class='clear']";
            public const string PriceSelector = "div[class='moduletable'] div[class='vmgroup'] div[class='product-price'] div [class='PricesalesPrice']";
        }
    }
}
