using System;
using AutoMapper;
using Painty.DAL.Entities;
using Painty.DTO;

namespace Painty.Mappings
{
	public class ImageProfile : Profile
	{
		public ImageProfile()
		{
			CreateMap<Image, ImageRequest>();
			CreateMap<ImageRequest, Image>();
		}
	}
}

