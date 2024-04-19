using System.ComponentModel.DataAnnotations;

namespace WebAppASPNETMVC.ViewModels;

public class SignInViewModel
{
    [Required]
    [Display(Name = "Email adress", Prompt = "Enter your email adress")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = null!;

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Password", Prompt = "Enter your password")]
	public string Password { get; set; } = null!;

	[Display(Name = "Remember me", Prompt = "Remember me")]
	public bool IsPresistent { get; set; } 
}
