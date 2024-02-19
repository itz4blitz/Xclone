using API.Models;

namespace API.Interfaces
{
    public interface ITweetService
    {
        Task<IEnumerable<Tweet>> GetAllTweetsAsync();
        Task<Tweet> GetTweetByIdAsync(int tweetId);
        Task<IEnumerable<Tweet>> GetTweetsByUserNameAsync(string userName);
        Task<Tweet> CreateTweetAsync(Tweet tweet);
    }
}
