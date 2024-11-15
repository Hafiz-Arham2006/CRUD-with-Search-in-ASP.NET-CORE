using CRUD_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Application.Controllers
{
    public class HomeController : Controller
    {
        NetCrudContext _context;
        public HomeController(NetCrudContext context)
        {
            _context = context;
        }
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Student std)
        {
            _context.Students.Add(std);
            _context.SaveChanges();
            return RedirectToAction("Fetch");
        }
        public IActionResult Fetch()
        {

            return View(_context.Students.ToList());
        }
        [HttpGet]
        public IActionResult Fetch(string search)
        {
            List<Student> obj = new List<Student>();
            if (string.IsNullOrEmpty(search))
            {
                obj=_context.Students.ToList();
            }
            else
            {
                obj = _context.Students.FromSqlInterpolated($"select * from students Where name like {search} + '%'").ToList();
                if (obj.Count == 0)
                {
                    ViewBag.msg = "No User Found!";
                }
            }
            return View(obj);
        }
        public IActionResult Delete(int id)
        {
           var std_id=_context.Students.Find(id);
            _context.Students.Remove(std_id);
             _context.SaveChanges();
            return RedirectToAction("Fetch");
        }

        public IActionResult Update(int id)
        {
            return View(_context.Students.Find(id)); 
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            _context.Students.Update(std);
            _context.SaveChanges();
           return RedirectToAction("Fetch");
        }

    }
}
