using System;
using AutoMapper;
using Painty.BLL.DTO;
using Painty.BLL.Interfaces;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;

namespace Painty.BLL.Services
{
	public class ImageService : IImageService
	{
		private readonly IRepository<Image> _imageRepository;

		private readonly IMapper _mapper;

		public ImageService(IRepository<Image> imageRepository, IMapper mapper)
		{
			_imageRepository = imageRepository;
			_mapper = mapper;
		}

        public async Task AddImageAsync(ImageDTO image)
        {
            var imageToAdd = _mapper.Map<Image>(image);
            await _imageRepository.Add(imageToAdd);
        }

        public async Task DeleteImageAsync(int imageId)
        {
            await _imageRepository.Delete(imageId);
        }

        public async Task<ImageDTO> GetImageByIdAsync(int imageId)
        {
            var image = await _imageRepository.GetById(imageId);
            return _mapper.Map<ImageDTO>(image);
        }

        public async Task<IEnumerable<ImageDTO>> GetImagesByUserIdAsync(int userId)
        {
            var images = await _imageRepository.GetAll();

            var userImages = images
                .Where(image => image.UserId == userId);

            return _mapper.Map<IEnumerable<ImageDTO>>(userImages);
        }
    }
}

