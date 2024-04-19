using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models;

public class SubscribeModel
{
    [Required]
    [DataType(DataType.EmailAddress)] //KAnske ska vara [EmailAdress]
    [Display(Name = "Email", Prompt ="Enter your email adress...")]
    public string Email { get; set; } = null!;
    public bool DailyNewsLetter { get; set; }
    public bool AdvertisingUpdate { get; set; }
    public bool WeekinReview { get; set; }  
    public bool EventUpdates { get; set; }
    public bool StartupWeekly { get; set; }
    public bool Podcast { get; set; }
}
