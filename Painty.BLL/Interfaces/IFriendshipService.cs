using System;
using Painty.BLL.DTO;

namespace Painty.BLL.Interfaces
{
	public interface IFriendshipService
	{
        //Task<FriendshipDTO> GetFriendshipByIdAsync(int frinedshipId);

        Task<IEnumerable<FriendshipDTO>> GetFriendshipsByUserIdAsync(int userId);

        Task AddFriendshipAsync(FriendshipDTO friendship);
    }
}

