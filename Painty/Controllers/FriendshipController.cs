using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Painty.BLL.DTO;
using Painty.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Painty.Controllers
{
    [Route("api/[controller]")]
    public class FriendshipController : Controller
    {
        private readonly IFriendshipService _friendshipService;

        public FriendshipController(IFriendshipService friendshipService)
        {
            _friendshipService = friendshipService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFriend([FromBody] FriendshipDTO friendship)
        {
            await _friendshipService.AddFriendshipAsync(friendship);

            return Ok("Friendship added successfully");
        }

        public async Task<IActionResult> RemoveFriendship(int userId, int friendId)
        {
            bool success = await _friendshipService.RemoveFriendshipAsync(userId, friendId);

            if (success)
            {
                return Ok("Friendship removed successfully");
            }
            else
            {
                return BadRequest("Failed to remove friendship");
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

