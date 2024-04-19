using Azure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WebAppASPNETMVC.ViewModels;

namespace WebAppASPNETMVC.Controllers;

public class DefaultController(HttpClient httpClient) : Controller
{
	private readonly HttpClient _httpClient = httpClient;

    public IActionResult Home()
    {
        //var viewModel = new HomeIndexViewModel().GetInformation();

        //ViewData["Title"] = viewModel.Title;

        return View();
	}

	[HttpPost]
	public async Task<IActionResult> Subscribe(SubscribeModel model)
	{
		if(ModelState.IsValid)
		{
			var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
			var respons = await _httpClient.PostAsync("https://localhost:7252/api/Subscribe", content);  

            if (respons.IsSuccessStatusCode)
			{
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if (respons.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                TempData["StatusMessage"] = "You are already subscribed";
            }
			
        }
        else
        {
            TempData["StatusMessage"] = "Something went wrong. Try again";
        }


        return RedirectToAction("Home", "Default", "subscribe");
	}
}
