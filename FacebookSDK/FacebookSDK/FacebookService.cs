namespace FacebookSDK
{
    using System.Threading.Tasks;

    using Contracts;

    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            _facebookClient = facebookClient;
        }

        public async Task PostOnWallAsync(string accessToken, object message)
            => await _facebookClient.PostAsync(accessToken, "/feed", new { message });
    }
}
