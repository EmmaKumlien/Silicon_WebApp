using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppASPNETMVC.ViewModels;

namespace WebAppASPNETMVC.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, DataContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly DataContext _context = context;

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
	[Route("/signup")]
	public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if(!await _context.Users.AnyAsync(x=>x.Email == model.Form.Email))
            {
                var userEntity = new UserEntity
                {
                    Email = model.Form.Email,
                    UserName = model.Form.Email,
                    FirstName = model.Form.FirstName,
                    LastName = model.Form.LastName,

                };
                if((await _userManager.CreateAsync(userEntity, model.Form.PassWord)).Succeeded)
                {
                    if ((await _signInManager.PasswordSignInAsync(model.Form.Email, model.Form.PassWord, false, false)).Succeeded)
                    {
                        return LocalRedirect("/");
                    }
                    else
                    {
                        return LocalRedirect("/signin");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Try again later or contact sutomer service.";
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email adress already exists";
            }
        }

        return View(model);
    }


    [HttpGet]
	[Route("/signin")]
	public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }


    [HttpPost]
	[Route("/signin")]
	public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
        if(ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.IsPresistent, false)).Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
        }
        
        ViewData["ReturnUrl"] = returnUrl;
        ViewData["StatusMessage"] = "Incorrect email or password";
        return View(model);
    }

	[Route("/signout")]
	public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Default");
    }
}
