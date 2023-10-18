using System;
using Painty.BLL.Interfaces;
using Painty.BLL.Services;
using Painty.DAL.Entities;
using Painty.DAL.Interfaces;
using Painty.DAL.Repositories;

namespace Painty
{
	public static class Initializer
	{
		public static void InitializeRepositories(this IServiceCollection services)
		{
			services.AddScoped<IRepository<User>, UserRepository>();
			services.AddScoped<IRepository<Image>, ImageRepository>();
			services.AddScoped<IRepository<Friendship>, FriendshipRepository>();
		}

		public static void InitializeServices(this IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<IFriendshipService, FriendshipService>();
		}

    }
}

