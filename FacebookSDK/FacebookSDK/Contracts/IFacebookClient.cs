namespace FacebookSDK.Contracts
{
    using System.Threading.Tasks;

    public interface IFacebookClient
    {
        Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null);

        Task PostAsync(string accessToken, string endpoint, object data, string args = null);
    }
}
