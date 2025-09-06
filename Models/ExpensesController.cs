using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Models;
using System.Linq;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ExpenseDbContext _context;

        public ExpensesController(ExpenseDbContext context)
        {
            _context = context;
        }

        // GET: /Expenses
        public IActionResult Index()
        {
            var expenses = _context.Expenses.ToList();
            return View(expenses);
        }

        // GET: /Expenses/Details/5
        public IActionResult Details(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // GET: /Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Expenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(expense);
        }

        // GET: /Expenses/Edit/5
        public IActionResult Edit(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: /Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Expense expense)
        {
            if (id != expense.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                _context.Update(expense);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(expense);
        }

        // GET: /Expenses/Delete/5
        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
                return NotFound();

            return View(expense);
        }

        // POST: /Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
