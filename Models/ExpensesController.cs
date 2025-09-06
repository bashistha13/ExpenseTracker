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
            if (expense == null) return NotFound();
            return View(expense);
        }

        // POST: /Expenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Expense expense)
        {
            if (!ModelState.IsValid)
                return View(expense);

            var existingExpense = _context.Expenses.FirstOrDefault(e => e.Id == expense.Id);
            if (existingExpense == null) return NotFound();

            existingExpense.Name = expense.Name;
            existingExpense.Description = expense.Description;
            existingExpense.Amount = expense.Amount;
            existingExpense.Category = expense.Category;
            existingExpense.Date = expense.Date;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Expenses/Delete/5
        public IActionResult Delete(int id)
        {
            var expense = _context.Expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null) return NotFound();
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
