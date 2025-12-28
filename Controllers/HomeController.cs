using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BibliotekaProjekt.Models;
using BibliotekaProjekt.Data; 

namespace BibliotekaProjekt.Controllers;

public class HomeController : Controller
{
    private readonly BibliotekaContext _context;

    public HomeController(BibliotekaContext context)
    {
        _context = context;
    }

    public IActionResult Index(string fraza)
{
    var zasoby = _context.Zasoby.AsQueryable();

    if (!string.IsNullOrEmpty(fraza))
    {
        zasoby = zasoby.Where(z => z.Tytul.Contains(fraza) 
                                || (z is Ksiazka && ((Ksiazka)z).Autor.Contains(fraza)));
    }

    return View(zasoby.ToList());
}

    public IActionResult Usun(int id)
{
    var zasob = _context.Zasoby.Find(id); 
    if (zasob != null)
    {
        _context.Zasoby.Remove(zasob); 
        _context.SaveChanges(); 
    }
    return RedirectToAction("Index"); 
}

    public IActionResult DodajKsiazke()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DodajKsiazke(Ksiazka nowaKsiazka)
    {
        if (ModelState.IsValid)
        {
            _context.Zasoby.Add(nowaKsiazka); 
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }
        return View(nowaKsiazka); 
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}