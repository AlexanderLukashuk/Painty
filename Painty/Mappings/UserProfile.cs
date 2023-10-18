using System;
using AutoMapper;
using Painty.DTO;
using Painty.DAL.Entities;

namespace Painty.Mappings
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
		}
	}
}

