using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpenseTracker.Models;
using System.Linq;

public class ExpensesController : Controller
{
    private readonly ExpenseDbContext _context;

    public ExpensesController(ExpenseDbContext context)
    {
        _context = context;
    }

    // GET: Expenses/Edit/5
    public IActionResult Edit(int id)
    {
        var expense = _context.Expenses.Find(id);
        if (expense == null)
        {
            return NotFound();
        }

        ViewBag.Categories = new SelectList(new[] { "Food", "Travel", "Shopping", "Other" }, expense.Category);
        return View(expense);
    }

    // POST: Expenses/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Expense expense)
    {
        if (id != expense.Id) return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(expense);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Categories = new SelectList(new[] { "Food", "Travel", "Shopping", "Other" }, expense.Category);
        return View(expense);
    }
}
