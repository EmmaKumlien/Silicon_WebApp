namespace WebAppASPNETMVC.ViewModels
{
	public class HomeIndexViewModel
	{
		public string Title { get; set; } = null!;
		public ShowcaseViewModel Showcase { get; set; } = null!;

		public HomeIndexViewModel GetInformation()
		{
			var viewModel = new HomeIndexViewModel
			{
				Title = "Home",
				Showcase = new ShowcaseViewModel
				{
					Id = "showcase",
					Title = "Task Management Assistant You Gonna Love",
					Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.",
					Link = new() { ControllerName = "Courses", ActionName = "Index", Text = "Get started for free" },
					BrandsText = "Largest companies use our tool to work efficiently",
					Brands =
				   [
						new() {ImageURL = "~/images/Home/Showcase/logo1.svg", ImageText="Logotype1"},
					new() {ImageURL = "~/images/Home/Showcase/logo2.svg", ImageText="Logotype2"},
					new() {ImageURL = "~/images/Home/Showcase/logo3.svg", ImageText="Logotype3"},
					new() {ImageURL = "~/images/Home/Showcase/logo4.svg", ImageText="Logotype4"},


					],
					ShowcaseImage = new() { ImageURL = "~/images/Home/Showcase/imageshowcase.svg", ImageText = "Picture of a taskboard layout" }

				},
			};

			return viewModel;
		}

	}
}
