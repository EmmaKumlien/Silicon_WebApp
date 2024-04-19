using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services;

public class AccountService(UserManager<UserEntity> userManager, DataContext context)
{
	private readonly UserManager<UserEntity> userManager = userManager;
	private readonly DataContext _context = context;

	public bool UpdateBasicInfo()
	{
		try
		{


			return true;
		}
		catch { return false; }
	}

	public bool UpdateAdressInfo()
	{
		try
		{

			return true;
		}
		catch { return false; }
	}
}
