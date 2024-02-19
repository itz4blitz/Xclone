using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class TweetService : ITweetService
    {
        private readonly ApplicationDbContext _context;

        public TweetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tweet>> GetAllTweetsAsync()
        {
            return await _context.Tweets.ToListAsync();
        }

        public async Task<Tweet> GetTweetByIdAsync(int tweetId)
        {
            var tweet = await _context.Tweets.FindAsync(tweetId) ?? throw new KeyNotFoundException($"Tweet with Id {tweetId} not found.");
            return tweet;
        }

        public async Task<IEnumerable<Tweet>> GetTweetsByUserNameAsync(string userName)
        {
            return await _context.Tweets
                                .Where(t => t.UserName == userName)
                                .ToListAsync();
        }

        public async Task<Tweet> CreateTweetAsync(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            await _context.SaveChangesAsync();
            return tweet;
        }
    }
}
