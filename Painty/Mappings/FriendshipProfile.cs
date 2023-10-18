using System;
using AutoMapper;
using Painty.BLL.DTO;
using Painty.DAL.Entities;

namespace Painty.Mappings
{
	public class FriendshipProfile : Profile
	{
		public FriendshipProfile()
		{
            CreateMap<Friendship, FriendshipDTO>();
            CreateMap<FriendshipDTO, Friendship>();
        }
	}
}

