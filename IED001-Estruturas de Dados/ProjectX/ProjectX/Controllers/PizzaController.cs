    using Microsoft.AspNetCore.Mvc;
    using ProjectX.Models;

    namespace ProjectX.Controllers
    {
        public class PizzaController : Controller
        {
            // GET: Pizza
            public ActionResult Index()
            {
                using (PizzaModel model = new PizzaModel())
                {
                    List<Pizza> lista = model.Read();
                    return View(lista);
                }
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
                Pizza pizza = new Pizza();
                pizza.Nome = form["Nome"];
                pizza.Ingredientes = form["Ingredientes"];
                pizza.Valor = int.Parse(form["Valor"]);

                using (PizzaModel model = new PizzaModel())
                {
                    model.Create(pizza);
                    return RedirectToAction("Index");
                }
            }

            // GET: Pizza/Edit/5
            public ActionResult Edit(int id)
            {
                using (PizzaModel model = new PizzaModel())
                {
                    Pizza pizza = model.Read().FirstOrDefault(p => p.IdPizza == id);
                    if (pizza == null)
                    {
                        return NotFound();
                    }
                    return View(pizza);
                }
            }

            // POST: Pizza/Edit
            // POST: Pizza/Edit
            [HttpPost]
            public ActionResult Edit(Pizza pizza) // Recebe o objeto Pizza completo
            {
                using (PizzaModel model = new PizzaModel())
                {
                    model.Update(pizza);
                    return RedirectToAction("Index");
                }
            }
            
            // GET: Pizza/Delete/5
            public ActionResult Delete(int id)
            {
                using (PizzaModel model = new PizzaModel())
                {
                    Pizza pizza = model.Read().FirstOrDefault(p => p.IdPizza == id);
                    if (pizza == null)
                    {
                        return NotFound();
                    }
                    return View(pizza);
                }
            }

            // POST: Pizza/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, IFormCollection collection)
            {
                using (PizzaModel model = new PizzaModel())
                {
                    model.Delete(id);
                    return RedirectToAction("Index");
                }
            }
        }
    }