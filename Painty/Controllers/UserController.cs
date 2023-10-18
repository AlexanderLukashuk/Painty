using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Painty.BLL.Interfaces;
using Painty.DTO;
using Painty.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Painty.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("UserId")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpGet("{userId}/friends")]
        public async Task<IActionResult> GetFriends(int userId)
        {
            var friends = await _userService.GetFriendsAsync(userId);
            var friendDTOs = _mapper.Map<IEnumerable<FriendDTO>>(friends);
            return Ok(friendDTOs);
        }

        [HttpPost("{userId}/add-friend")]
        public async Task<IActionResult> AddFriend(int userId, [FromBody] AddFriendRequest request)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var friend = await _userService.GetUserByIdAsync(request.FriendId);
            if (friend == null)
            {
                return NotFound();
            }

            await _userService.AddFriendAsync(userId, request.FriendId);
            return NoContent();
        }
    }
}

