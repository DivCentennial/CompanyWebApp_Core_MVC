
using CompanyWebApp_Core_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyWebApp_Core_MVC.Controllers
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

        // GET: Departments/Delete/5
        public IActionResult Delete(int id)
        {
            var dept = dl.GetDepartment(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int Department_ID)
        {
            dl.DeleteDepartment(Department_ID);
            return RedirectToAction(nameof(Index));
        }
    }
}
