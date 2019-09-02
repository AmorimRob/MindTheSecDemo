using System;
using System.Collections.Generic;
using MindTheSecDemo.ViewModels;
using Xamarin.Forms;

namespace MindTheSecDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }
}
