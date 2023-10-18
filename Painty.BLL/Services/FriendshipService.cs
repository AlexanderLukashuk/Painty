using System;
using AutoMapper;
using Painty.BLL.DTO;
using Painty.BLL.Interfaces;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.BLL.Services
{
	public class FriendshipService : IFriendshipService
	{
		private readonly IRepository<Friendship> _friendshipRepository;

		private readonly IMapper _mapper;

		public FriendshipService(IRepository<Friendship> friendshipRepository, IMapper mapper)
		{
			_friendshipRepository = friendshipRepository;
			_mapper = mapper;
		}

        public async Task AddFriendshipAsync(FriendshipDTO friendship)
        {
			var friendshipToAdd = _mapper.Map<Friendship>(friendship);
			await _friendshipRepository.Add(friendshipToAdd);
        }

        public async Task<IEnumerable<FriendshipDTO>> GetFriendshipsByUserIdAsync(int userId)
        {
			var friendship = await _friendshipRepository.GetAll();

			var filteredFriendships = friendship
				.Where(f => f.User1Id == userId || f.User2Id == userId);

			return _mapper.Map<IEnumerable<FriendshipDTO>>(filteredFriendships);
		}

        public async Task<bool> RemoveFriendshipAsync(int userId, int friendId)
        {
			var friendships = await _friendshipRepository.GetAll();

			var friendship = friendships
				.FirstOrDefault(f => (f.User1Id == userId && f.User2Id == friendId) ||
				(f.User1Id == friendId && f.User2Id == userId));

			if (friendship != null)
			{
				await _friendshipRepository.Delete(friendship.Id);
				return true;
			}

			return false;
        }
    }
}

