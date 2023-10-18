using System;
using Painty.BLL.DTO;

namespace Painty.BLL.Interfaces
{
	public interface IUserService
	{
		Task<UserDTO> GetUserByIdAsync(int userId);

		Task<IEnumerable<UserDTO>> GetFriendsAsync(int userId);

		Task AddFriendAsync(int userId, int friendId);

        //Task<bool> AreFriendsAsync(int userId, int friendId);

        Task<IEnumerable<ImageDTO>> GetImagesByUserIdAsync(int userId);
    }
}

