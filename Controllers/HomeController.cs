using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using webapp_net8_database.Data;
using webapp_net8_database.Models;

namespace webapp_net8_database.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly MyDbContext myDbContext;

		public HomeController(MyDbContext _myDbContext)
		{
			this.myDbContext = _myDbContext;
		}

		[HttpGet]
		public IActionResult Index() => View();

		[HttpGet]
		public IActionResult JSTest() => View();

		[HttpGet]
		public IActionResult AddEntry() => View();

		[HttpPost]
		public IActionResult AddEntry([FromForm]MyDbModel model)
		{
			if(ModelState.IsValid)
			{
				model.TimeStamp = DateTime.Now;
				myDbContext.Add<MyDbModel>(model);
				myDbContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpGet]
		public IActionResult EditEntry([FromRoute]int id)
		{
			if(ModelState.IsValid)
			{
				MyDbModel? entry = myDbContext.Find<MyDbModel>(id);
				if (entry != null)
				{
					return View(entry);
				}
			}

			return RedirectToAction(nameof(Index));
		}

		[HttpPost]
		public IActionResult EditEntry([FromForm]MyDbModel model)
		{
			if(ModelState.IsValid)
			{
				MyDbModel? entryToEdit = myDbContext.Find<MyDbModel>(model.Id);
				if(entryToEdit != null)
				{
					entryToEdit.Name = model.Name;
					myDbContext.Update<MyDbModel>(entryToEdit);
					myDbContext.SaveChanges();

					return RedirectToAction(nameof(Index));
				}
			}

			return View(model);
		}

		[HttpPost]
		public IActionResult DeleteEntry([FromRoute]int id)
		{
			if(ModelState.IsValid)
			{
				MyDbModel? entryToDelete = myDbContext.Find<MyDbModel>(id);
				if(entryToDelete != null)
				{
					myDbContext.Remove<MyDbModel>(entryToDelete);
					myDbContext.SaveChanges();

					return RedirectToAction(nameof(Index));
				}
			}

			return RedirectToAction(nameof(EditEntry), id);
		}
	}
}
