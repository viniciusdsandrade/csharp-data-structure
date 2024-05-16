using Microsoft.AspNetCore.Mvc;
using ProjectX.Models;

namespace ProjectX.Controllers;

public class PizzaController : Controller
{
    // GET: Pizza
    public ActionResult Index()
    {
        using var model = new PizzaModel();
        List<Pizza> lista = model.Read();
        return View(lista);
    }

    // GET: Pizza/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Pizza/Create
    [HttpPost]
    public ActionResult Create(IFormCollection form)
    {
        var pizza = new Pizza(
            0, // IdPizza será gerado pelo banco, iniciamos com 0
            form["Nome"]!,
            form["Ingredientes"]!,
            int.Parse(form["Valor"]!)
        );

        using var model = new PizzaModel();
        model.Create(pizza);
        return RedirectToAction("Index");
    }

    // GET: Pizza/Edit/5
    public ActionResult Edit(int id)
    {
        using var model = new PizzaModel();
        var pizza = model.Read().FirstOrDefault(p => p.GetIdPizza() == id);
        if (pizza == null) return NotFound();

        return View(pizza);
    }

    // POST: Pizza/Edit
    [HttpPost]
    public ActionResult Edit(Pizza pizza) // Recebe o objeto Pizza completo
    {
        using var model = new PizzaModel();
        model.Update(pizza);
        return RedirectToAction("Index");
    }

    // GET: Pizza/Delete/5
    public ActionResult Delete(int id)
    {
        using var model = new PizzaModel();
        var pizza = model.Read().FirstOrDefault(p => p.GetIdPizza() == id);
        if (pizza == null) return NotFound();

        return View(pizza);
    }

    // POST: Pizza/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        using var model = new PizzaModel();
        model.Delete(id);
        return RedirectToAction("Index");
    }
}