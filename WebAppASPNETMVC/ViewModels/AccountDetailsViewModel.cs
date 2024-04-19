using System.ComponentModel.DataAnnotations;

namespace WebAppASPNETMVC.ViewModels;

public class AccountDetailsViewModel
{
	public AccountBasicinfo? BasicInfo { get; set; }
	public AccountAdressInfo? AdressInfo { get; set; }
}




public class AccountBasicinfo
{
	[Required]
	[Display(Name = "First name", Prompt = "Enter your first name")]
	public string FirstName { get; set; } = null!;

	[Required]
	[Display(Name = "Last name", Prompt = "Enter your your last name")]
	public string LastName { get; set; } = null!;


	[Required]
	[Display(Name = "Email adress", Prompt = "Enter your email adress")]
	[DataType(DataType.EmailAddress)]
	public string Email { get; set; } = null!;


	[DataType(DataType.PhoneNumber)]
	[Display(Name = "Phone number", Prompt = "Enter your phone number")]
	public string? PhoneNumber { get; set; }


	[DataType(DataType.MultilineText)]
	[Display(Name = " Bio", Prompt = "Write something about yourself...")]
	public string? Bio { get; set; } 
}

public class AccountAdressInfo
{
	[Required]
	[Display(Name = "Adress line 1", Prompt = "Enter adress")]
	public string AdressLine_1 { get; set; } = null!;

	[Display(Name = "Adress line 2", Prompt = "Enter second adress")]
	public string? AdressLine_2 { get; set; }

	[Required]
	[Display(Name = "Postal code", Prompt = "Write your postal code")]
	[DataType(DataType.PostalCode)]
	public string Postalcode { get; set; } = null!;

	[Required]
	[Display(Name = "City", Prompt = "Enter name of city")]
	public string City { get; set; } = null!;
}