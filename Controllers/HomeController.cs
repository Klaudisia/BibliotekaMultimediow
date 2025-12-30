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

    public IActionResult DodajEbook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DodajEbook(Ebook nowyEbook)
    {
        if (ModelState.IsValid)
        {
            _context.Zasoby.Add(nowyEbook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(nowyEbook);
    }

    public IActionResult DodajFilm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DodajFilm(Film nowyFilm)
    {
        if (ModelState.IsValid)
        {
            _context.Zasoby.Add(nowyFilm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(nowyFilm);
    }

    public IActionResult EdytujKsiazke(int id)
    {
        var ksiazka = _context.Ksiazki.Find(id);
        if(ksiazka == null)
        {
            return NotFound();
        }
        return View(ksiazka);
    }

    [HttpPost]
    public IActionResult EdytujKsiazke(Ksiazka edytowanaKsiazka)
    {
        if (ModelState.IsValid)
        {
            _context.Ksiazki.Update(edytowanaKsiazka);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(edytowanaKsiazka);
    }

    public IActionResult EdytujEbook(int id)
    {
        var ebook = _context.Ebook.Find(id);
        if(ebook == null)
        {
            return NotFound();
        }
        return View(ebook);
    }

    [HttpPost]
    public IActionResult EdytujEbook(Ebook edytowanyEbook)
    {
        if (ModelState.IsValid)
        {
            _context.Ebook.Update(edytowanyEbook);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(edytowanyEbook);
    }

    public IActionResult EdytujFilm(int id)
    {
        var film = _context.Filmy.Find(id);
        if(film == null)
        {
            return NotFound();
        }
        return View(film);
    }

    [HttpPost]
    public IActionResult EdytujFilm(Film edytowanyFilm)
    {
        if (ModelState.IsValid)
        {
            _context.Filmy.Update(edytowanyFilm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(edytowanyFilm);
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