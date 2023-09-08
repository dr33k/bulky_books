using BulkyBooks.Data;
using BulkyBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBooks.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;        
    }
    public IActionResult Index(){
        IEnumerable<Category> categories = _db.Categories;
        return View(categories);
    }
        public IActionResult Create(){
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category){
        if(ModelState.IsValid){
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToAction("Index");
        }
        else return View();
       
    }

        public IActionResult Edit(int? id){
            if(id is null) return NotFound();

            var result = _db.Categories.Find(id);

            if(result is null) return NotFound();


        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category){
                    //ModelState.AddModelError("Custome", "Dont Gimme That");
        if(ModelState.IsValid){
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["success"] = "Category updated successfully";
            return RedirectToAction("Index");
        }
        else return View();
       
    }

    public IActionResult Delete(int? id){
        if(id is null) return NotFound();
        Category? category = _db.Categories.Find(id);  
        return (category is null)? NotFound() : View(category); 
    }

    [HttpPost, ActionName("DeletePOST")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Category category){
        _db.Categories.Remove(category);
        _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}
