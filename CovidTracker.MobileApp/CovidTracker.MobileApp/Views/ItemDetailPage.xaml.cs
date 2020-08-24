using System.ComponentModel;
using Xamarin.Forms;
using CovidTracker.MobileApp.ViewModels;

namespace CovidTracker.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}