namespace FacebookSDK.Common
{
    public static class GlobalConstants
    {
        public static class Startup
        {
            public const string Url = "http://vtora-upotreba.org/";
            public const string FileName = "settings.json";
        }

        public static class Upload 
        {
            public const string PhotoPost = "/photos";
            public const string FeedPost = "/feed";
            public const string UrlPost = "url";
            public const string MessagePost ="message";
        }

        public static class Engine
        {
            public const int SleepingTime = 5000;
            public const string Message = "🛒 {0}\n💴 Цена: {1}\n🌎 {2}\n‼ Детайли: ⬇⬇⬇⬇\n✅ {3}";
            public const string PostId = "Post Id:";
            public const string ResultId = "id";
            public const string Json = "Json:";
            public const string Time = "Time:";
            public const string ExeptonFileName = "exception.txt";
            public const string LastPostLinkFileName = "lastPostLink.txt";
        }
    }
}
