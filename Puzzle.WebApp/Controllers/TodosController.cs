using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Puzzle.WebApp.Models;
using System.Diagnostics;
using Puzzle.WebApp.Services.Interfaces;
using System.Threading.Tasks;
using Puzzle.WebApp.Infrastructure;

namespace Puzzle.WebApp.Controllers
{
    public class TodosController : Controller
    {
        #region fields
        private readonly IBaseService<Todo> _todoService;
        #endregion

        #region constructor
        public TodosController(IBaseService<Todo> todoService)
        {
            _todoService = todoService;
        }
        #endregion

        // GET: Todos
        public async Task<ActionResult> Index()
        {            
            Trace.WriteLine("GET /Todos/Index");
            var todoList = await _todoService.GetAllAsync();
            return View(todoList);
        }

        // GET: Todos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            Trace.WriteLine("GET /Todos/Details/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = await _todoService.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Todos/Create");
            return View(new Todo { CreatedDate = DateTime.Now });
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Description,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Todos/Create");
            if (ModelState.IsValid)
            {
                await _todoService.CreateAsync(todo);
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            Trace.WriteLine("GET /Todos/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = await _todoService.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Description,CreatedDate")] Todo todo)
        {
            Trace.WriteLine("POST /Todos/Edit/" + todo.ID);
            if (ModelState.IsValid)
            {
                await _todoService.UpdateAsync(todo);
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            Trace.WriteLine("GET /Todos/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = await _todoService.GetByIdAsync(id.Value);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Todos/Delete/" + id);

            await _todoService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
