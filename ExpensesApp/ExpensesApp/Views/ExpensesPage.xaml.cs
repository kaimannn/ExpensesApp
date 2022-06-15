using ExpensesApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesPage : ContentPage
    {
        private readonly ExpensesVM ViewModel;

        public ExpensesPage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as ExpensesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpenses();
        }
    }
}