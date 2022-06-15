using ExpensesApp.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExpensesApp.ViewModels
{
    public class CategoriesVM
    {
        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<CategoryExpenses> CategoryExpensesCollection { get; set; }

        public CategoriesVM()
        {
            Categories = new ObservableCollection<string>();
            CategoryExpensesCollection = new ObservableCollection<CategoryExpenses>();
            GetCategories();
            GetExpensePerCategory();
        }

        private void GetCategories()
        {
            Categories.Clear();
            Categories.Add("Housing");
            Categories.Add("Debt");
            Categories.Add("Health");
            Categories.Add("Food");
            Categories.Add("Personal");
            Categories.Add("Travel");
            Categories.Add("Other");
        }

        public void GetExpensePerCategory()
        {
            CategoryExpensesCollection.Clear();

            float totalExpensesAmount = Expense.TotalExpensesAmount();
            foreach (string category in Categories)
            {
                var expenses = Expense.GetExpenses(category);
                float expensesAmountInCategory = expenses.Sum(e => e.Amount);

                var categoryExpenses = new CategoryExpenses
                {
                    Category = category,
                    ExpensesPercentage = expensesAmountInCategory / totalExpensesAmount
                };

                CategoryExpensesCollection.Add(categoryExpenses);
            }
        }

        public class CategoryExpenses
        {
            public string Category { get; set; }
            public float ExpensesPercentage { get; set; }
        }
    }
}
