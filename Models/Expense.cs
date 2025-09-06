namespace ExpenseTracker.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Category { get; set; } = string.Empty;

    
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
