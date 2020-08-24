using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CovidTracker.MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GreetPage : ContentPage
    {
        public GreetPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Alert Box Title", "Hello World", "Okay");
        }
    }
}