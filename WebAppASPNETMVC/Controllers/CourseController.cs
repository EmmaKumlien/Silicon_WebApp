using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppASPNETMVC.ViewModels;

namespace WebAppASPNETMVC.Controllers;

[Authorize]
public class CourseController(HttpClient httpClient) : Controller
{

	private readonly HttpClient _httpClient = httpClient;

	[Route("/courses")]
	public async Task<IActionResult> Index()
    {
		var viewModel = new CourseIndexViewModel();
		
		var response = await _httpClient.GetAsync("https://localhost:7252/api/Courses");
		if (response.IsSuccessStatusCode)
		{
			
			var courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(await response.Content.ReadAsStringAsync()); 
			if(courses != null && courses.Any())
			{
				viewModel.Course = courses;
			}
			
		}

		ViewData["Title"] = "Course Library";
		return View(viewModel);

	}
}
