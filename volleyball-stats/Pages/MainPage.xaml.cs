namespace volleyball_stats.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public async void navigateToCreateMatch(object? sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new CreateMatchPage());

        }
    }

}
