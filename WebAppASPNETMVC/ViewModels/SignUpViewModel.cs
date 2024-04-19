using Infrastructure.Filters;
using Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace WebAppASPNETMVC.ViewModels;

public class SignUpViewModel
{
	public string Title { get; set; } = "Sign up";
	public SignUpModel Form { get; set; } = new SignUpModel();
}
