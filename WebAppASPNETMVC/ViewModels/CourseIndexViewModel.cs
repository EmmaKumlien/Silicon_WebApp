using Infrastructure.Models;

namespace WebAppASPNETMVC.ViewModels;

public class CourseIndexViewModel
{
	public IEnumerable<CourseModel> Course { get; set; } = [];
}
