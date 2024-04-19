using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebAppASPNETMVC.ViewModels;

namespace WebAppASPNETMVC.Controllers;
[Authorize]
public class AccountController(UserManager<UserEntity> userManager, DataContext context, AccountService accountService) : Controller
{
	private readonly AccountService _accountService = accountService;
	private readonly UserManager<UserEntity> _userManager = userManager;
	private readonly DataContext _context = context;

	[Route("/account")]
	public async Task<IActionResult> Details()
    {
		var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
		var user = await _context.Users.Include(i => i.Adress).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

	
		var viewModel = new AccountDetailsViewModel
		{
			BasicInfo = new AccountBasicinfo
			{
				FirstName = user!.FirstName,
				LastName = user.LastName,
				Email = user.Email!,
				PhoneNumber = user.PhoneNumber,
				Bio = user.Bio
			},
			AdressInfo = new AccountAdressInfo
			{
				AdressLine_1 = user.Adress?.AdressLine_1!,
				AdressLine_2 = user.Adress?.AdressLine_2,
				Postalcode = user.Adress?.Postalcode!,
				City = user.Adress?.City!,
			}

			
		};
        return View(viewModel);
    }

	[HttpPost]
	public async Task<IActionResult> UpdateBasicInfo(AccountDetailsViewModel model)
	{
		if(TryValidateModel(model.BasicInfo!)) 
		{
			//var result = _accountService.UpdateBasicInfo(model.BasicInfo);Skriv om koden nedan i en áccountservice

			var user = await _userManager.GetUserAsync(User);
			if(user != null)
			{
				user.FirstName = model.BasicInfo!.FirstName;
				user.LastName = model.BasicInfo!.LastName;
				user.Email = model.BasicInfo!.Email;
				user.PhoneNumber = model.BasicInfo!.PhoneNumber;
				user.UserName = model.BasicInfo!.Email;
				user.Bio = model.BasicInfo!.Bio;

				var result = await _userManager.UpdateAsync(user);


				if(result.Succeeded)
				{
					TempData["StatusMessage"] = "Succesfully updated basic information";
				}
				else
				{
					TempData["StatusMessage"] = "Unable to save basic information";
				}
			}
		}
		else
		{
			TempData["StatusMessage"] = "Unable to save basic information";
		}

		return RedirectToAction("Details", "Account");
	}

	[HttpPost]
	public async Task<IActionResult> UpdateAdressInfo(AccountDetailsViewModel model)
	{
		if (TryValidateModel(model.AdressInfo!))
		{
			//var result = _accountService.UpdateAdressInfo(model.AdressInfo);

			var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
			var user = await _context.Users.Include(i => i.Adress).FirstOrDefaultAsync(x => x.Id == nameIdentifier);
			if (user != null)
			{
				try
				{
					if (user.Adress != null)
					{
						user.Adress.AdressLine_1 = model.AdressInfo!.AdressLine_1;
						user.Adress.AdressLine_2 = model.AdressInfo.AdressLine_2;
						user.Adress.Postalcode = model.AdressInfo.Postalcode;
						user.Adress.City = model.AdressInfo.City;
					}
					else
					{
						user.Adress = new AdressEntity
						{
							AdressLine_1 = model.AdressInfo!.AdressLine_1,
							AdressLine_2 = model.AdressInfo.AdressLine_2,
							Postalcode = model.AdressInfo.Postalcode,
							City = model.AdressInfo.City

						};
					}
					_context.Update(user);
					await _context.SaveChangesAsync();

					TempData["StatusMessage"] = "Succesfully updated adress information";

				}
				catch  
				{
					TempData["StatusMessage"] = "Unable to save adress information"; 
				}


			}
		}
		else
		{
			TempData["StatusMessage"] = "Unable to save adress information";
		}

		return RedirectToAction("Details", "Account");
	}

	[HttpPost]
	public async Task<IActionResult> UploadProfileImage(IFormFile file)
	{

		var result = await _accountService.UpdateProfileImage(User, file);
		

		if (result == true)
		{
			TempData["StatusMessage"] = "New profile picture uploaded";
			
		}
		else
		{
			TempData["StatusMessage"] = "Unable to upload profile picture";
		}


		return RedirectToAction("Details", "Account");
	}
}
