namespace FacebookSDK.Contracts
{
    using System.Threading.Tasks;

    public interface IFacebookService
    {
        Task PostOnWallAsync(string accessToken, object message);
    }
}
