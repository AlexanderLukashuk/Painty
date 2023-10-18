using System;
using Painty.BLL.DTO;

namespace Painty.BLL.Interfaces
{
	public interface IImageService
	{
		Task<ImageDTO> GetImageByIdAsync(int imageId);

		Task<IEnumerable<ImageDTO>> GetImagesByUserIdAsync(int userId);

		Task AddImageAsync(ImageDTO image);

		Task DeleteImageAsync(int imageId);
	}
}

