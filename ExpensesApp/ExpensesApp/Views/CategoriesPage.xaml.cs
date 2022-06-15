using ExpensesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriesPage : ContentPage
    {
        private readonly CategoriesVM ViewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            ViewModel = Resources["vm"] as CategoriesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModel.GetExpensePerCategory();
        }
    }
}