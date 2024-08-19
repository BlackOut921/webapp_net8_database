using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using webapp_net8_database.Data;
using webapp_net8_database.Models;

namespace webapp_net8_database.Views.Shared.Components.TestDbComponent
{
	public class TestDbViewComponent : ViewComponent
	{
		private readonly MyDbContext myDbContext;

		public TestDbViewComponent(MyDbContext _myDbContext)
		{
			this.myDbContext = _myDbContext;
		}

		[HttpGet]
		public IViewComponentResult Invoke()
		{
			IEnumerable<MyDbModel> _entries = myDbContext.MyDbModels.ToList();
			return View(_entries);
		}
	}
}
