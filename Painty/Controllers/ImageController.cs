using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Painty.BLL.Interfaces;
using Painty.BLL.DTO;
using Painty.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Painty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public ImageController(IImageService imageService, IMapper mapper, IConfiguration configuration)
        {
            _imageService = imageService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("{imageId}")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            var image = await _imageService.GetImageByIdAsync(imageId);
            if (image == null)
            {
                return NotFound();
            }

            var imageDTO = _mapper.Map<ImageRequest>(image);
            return Ok(imageDTO);
        }

        [HttpPost("{userId}/upload")]
        public async Task<IActionResult> UploadImage(int userId, [FromBody] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var uploadPath = _configuration.GetSection("ImageUploadPath").Value;

            var filePath = Path.Combine(uploadPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            //var imageDto = new ImageDTO
            //{
            //    UserId = userId,
            //    Title = file.FileName
            //};

            var imageDto = new ImageDTO
            {
                UserId = userId,
                FileName = file.FileName
            };

            await _imageService.AddImageAsync(imageDto);

            return CreatedAtAction(nameof(GetImage), new { imageId = imageDto.Id }, imageDto);
        }
    }
}

