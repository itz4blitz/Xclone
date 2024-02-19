using Microsoft.AspNetCore.Mvc;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetsController : ControllerBase
    {
        private readonly ITweetService _tweetService;

        public TweetsController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }

        // GET: api/Tweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweets()
        {
            var tweets = await _tweetService.GetAllTweetsAsync();
            return Ok(tweets);
        }

        // POST: api/Tweets
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Tweet>> PostTweet(Tweet tweet)
        {
            // Assuming the user ID is extracted from the token in an earlier middleware
            var UserName = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (UserName == null)
            {
                return Unauthorized();
            }
            
            tweet.UserName = UserName; // Ensure the tweet is associated with the authenticated user
            var createdTweet = await _tweetService.CreateTweetAsync(tweet);
            return CreatedAtAction(nameof(GetTweet), new { id = createdTweet.Id }, createdTweet);
        }

        // GET: api/Tweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tweet>> GetTweet(int id)
        {
            var tweet = await _tweetService.GetTweetByIdAsync(id);
            if (tweet == null)
            {
                return NotFound();
            }

            return tweet;
        }

        // GET: api/Tweets/user/{userName}
        [HttpGet("user/{userName}")]
        public async Task<ActionResult<IEnumerable<Tweet>>> GetTweetsByUser(string userName)
        {
            var tweets = await _tweetService.GetTweetsByUserNameAsync(userName);
            return Ok(tweets);
        }
    }
}
