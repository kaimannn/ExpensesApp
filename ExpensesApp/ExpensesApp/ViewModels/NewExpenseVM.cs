using ExpensesApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace ExpensesApp.ViewModels
{
    public class NewExpenseVM : INotifyPropertyChanged
    {
        private string expenseName;
        public string ExpenseName
        {
            get { return expenseName; }
            set
            {
                expenseName = value;
                OnPropertyChanged("ExpenseName");
            }
        }

        private string expenseDescription;
        public string ExpenseDescription
        {
            get { return expenseDescription; }
            set
            {
                expenseDescription = value;
                OnPropertyChanged("ExpenseDescription");
            }
        }

        private float expenseAmount;
        public float ExpenseAmount
        {
            get { return expenseAmount; }
            set
            {
                expenseAmount = value;
                OnPropertyChanged("ExpenseAmount");
            }
        }

        private DateTime expenseDate;
        public DateTime ExpenseDate
        {
            get { return expenseDate; }
            set
            {
                expenseDate = value;
                OnPropertyChanged("ExpenseDate");
            }
        }

        private string expenseCategory;
        public string ExpenseCategory
        {
            get { return expenseCategory; }
            set
            {
                expenseCategory = value;
                OnPropertyChanged("ExpenseCategory");
            }
        }

        public Command SaveExpenseCommand { get; set; }
        public ObservableCollection<string> Categories { get; set; }

        public NewExpenseVM()
        {
            Categories = new ObservableCollection<string>();
            ExpenseDate = DateTime.Today;
            SaveExpenseCommand = new Command(InsertExpense);
            GetCategories();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertExpense()
        {
            var expense = new Expense
            {
                Name = ExpenseName,
                Amount = ExpenseAmount,
                Category = ExpenseCategory,
                Date = ExpenseDate,
                Description = ExpenseDescription
            };

            int result = Expense.InsertExpense(expense);
            if (result > 0)
                Application.Current.MainPage.Navigation.PopAsync();
            else
                Application.Current.MainPage.DisplayAlert("Error", "No items were inserted", "Ok");
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
    }
}
