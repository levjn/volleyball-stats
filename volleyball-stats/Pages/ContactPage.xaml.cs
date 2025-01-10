using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace volleyball_stats.Pages;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }
    
    public async void navigateToMainPage(object? sender, EventArgs eventArgs)
    {
        await Navigation.PushAsync(new MainPage());
    }
}