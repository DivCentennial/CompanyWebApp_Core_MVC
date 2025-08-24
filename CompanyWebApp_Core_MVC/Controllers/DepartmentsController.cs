
using CompanyWebApp_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    public class DepartmentsController : Controller
    {
        DataLayer dl = new DataLayer();

        public IActionResult Index()
        {
            return View(dl.GetDepartments());
        }

        public IActionResult Details(int id)
        {
            return View(dl.GetDepartment(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            dl.CreateDepartment(dept);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(dl.GetDepartment(id));
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            dl.UpdateDepartment(dept);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(dl.GetDepartment(id));
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            dl.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
