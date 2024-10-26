using Microsoft.AspNetCore.Mvc;
using CRUD_APP.Models; // Import classes from Models. (importing the CRUD_APP.Models namesspace)
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CRUD_APP.Controllers; 


public class ProductController : Controller
{
    private readonly AppDbContext _context; //Gives reading access to the database.

    //Constructor that takes in a variable of type AppDbContext whenever it's called.
    public ProductController(AppDbContext context) 
    {
        _context = context;
    }

    public IActionResult Index() //Index() Is the default URL pattern resolved to in controllers for {Action}
    { //IActionResult is an interface within Microsoft.AspNetCore.Mvc. It provides a way to define what an action should return to the client. When A user visits /Index. This method is what will fire.
        var products = _context.Products.ToList(); //queries Products property from AppDbContext. _context is of type AppDbContext, which gives access to its properties.
        //ToList() converts the items in the Products table into a list
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound(); // NotFound() returns a 404 response.
        }

        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create(Product product)
    {
        if (ModelState.IsValid)
        {
            _context.Products.Add(product); //Tracks the item to be added to the database. It will be added after SaveChanges() is called
            _context.SaveChanges(); //saves changes to the database, adding the tracked value from Add().
            return RedirectToAction(nameof(Index)); //Redirects user to the selected action
        }
        return View(product);
    }

    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Products.Update(product); //Update is for tracking a modified value
            _context.SaveChanges(); //Saves the changes to the modified value
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    
    
}