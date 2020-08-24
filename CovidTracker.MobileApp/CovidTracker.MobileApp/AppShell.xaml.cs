using System;
using System.Collections.Generic;
using CovidTracker.MobileApp.ViewModels;
using CovidTracker.MobileApp.Views;
using Xamarin.Forms;

namespace CovidTracker.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
