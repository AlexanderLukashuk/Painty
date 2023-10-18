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
			var friendship = _friendshipRepository.GetAll()
				.Where(f => f.User1Id == userId || f.User2Id == userId);
			return _mapper.Map<IEnumerable<FriendshipDTO>>(friendship);
        }
    }
}

