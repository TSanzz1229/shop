using Microsoft.AspNetCore.Mvc;
using Phone.Data.Repositories;
using Phone.Data.ViewModels;

namespace PhoneShopnet.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryCtl : Controller
	{
		private IUnit _unit;
		public CategoryCtl(IUnit unit) 
		{
			_unit = unit;
		}
		public IActionResult Index()
		{
			CategoryVM categoryVM = new CategoryVM();
			categoryVM.Categories = _unit.Category.GetAll();
			return View(categoryVM);
		}

		[HttpGet]
		public IActionResult CreateUpdate (int? ID)
		{
			CategoryVM vm = new CategoryVM();
			if(ID == null || ID == 0)
			{
				return View(vm);
			}
			else
			{
				vm.Category = _unit.Category.GetT(x => x.ID == ID);
				if(vm.Category == null)
				{
					return NotFound();
				}
				else
				{
					return View(vm);
				}
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateUpdate (CategoryVM vm)
		{
			if(ModelState.IsValid)
			{
				if(vm.Category.ID == 0)
				{
					_unit.Category.Add(vm.Category);
					TempData["Success"] = "Category create success";
                }
				else
				{
                    _unit.Category.Update(vm.Category);
                    TempData["Success"] = "Category update success";
                }
				_unit.Save();
				return RedirectToAction("Index");
			}
            return RedirectToAction("Index");
        }

		[HttpGet]
		public IActionResult Delete (int? Id)
		{
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
			var category = _unit.Category.GetT(x => x.ID == Id);
			if(category == null)
			{
				return NotFound();
			}
			return View(category);
        }

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteData (int? Id)
		{
			var category = _unit.Category.GetT(x => x.ID == Id);
			if(category == null)
			{
				return NotFound();
			}
			_unit.Category.Delete(category);
			_unit.Save();
			TempData["success"] = "Category delete done";
			return RedirectToAction("Index");
		}
	}
}
