using System;
using AutoMapper;
using Painty.BLL.DTO;
using Painty.BLL.Interfaces;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.BLL.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _userRepository;

		private readonly IRepository<Friendship> _friendshipRepository;

        private readonly IMapper _mapper;

		public UserService(IRepository<User> userRepository, IRepository<Friendship> friendshipRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_friendshipRepository = friendshipRepository;
            _mapper = mapper;
		}

        public async Task AddFriendAsync(int userId, int friendId)
        {
            var friendships = await _friendshipRepository.GetAll();
            var existingFriendship = friendships.FirstOrDefault(f =>
                (f.User1Id == userId && f.User2Id == friendId) ||
                (f.User1Id == friendId && f.User2Id == userId));

            if (existingFriendship == null)
            {
                var friendship = new Friendship
                {
                    User1Id = userId,
                    User2Id = friendId
                };
                await _friendshipRepository.Add(friendship);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetFriendsAsync(int userId)
        {
            var friendships = await _friendshipRepository.GetAll();
            var friendIds = friendships
                .Where(f => f.User1Id == userId || f.User2Id == userId)
                .Select(f => f.User1Id == userId ? f.User2Id : f.User1Id)
                .Distinct();

            var friends = new List<UserDTO>();
            foreach (var friendId in friendIds)
            {
                var friend = await _userRepository.GetById(friendId);
                if (friend != null)
                {
                    friends.Add(_mapper.Map<UserDTO>(friend));
                }
            }

            return friends;
        }

        public async Task<IEnumerable<ImageDTO>> GetImagesByUserIdAsync(int userId)
        {
            var user = await _userRepository.GetById(userId);
            return _mapper.Map<IEnumerable<ImageDTO>>(user.Images);
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetById(userId);
            return _mapper.Map<UserDTO>(user);
        }
    }
}

