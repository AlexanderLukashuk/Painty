using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Painty.BLL.Models
{
	public class ApplicationUser : IdentityUser
    {
		public string? FullName { get; set; }
	}
}

