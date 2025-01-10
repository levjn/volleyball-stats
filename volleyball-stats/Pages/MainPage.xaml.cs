namespace volleyball_stats.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();
        }

        public async void navigateToCreateMatch(object? sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new CreateMatchPage());
        }

        public async void navigateToInstructionsPage(object? sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new InstructionsPage());
        }

        public async void navigateToContactPage(object? sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new ContactPage());
        }
        
        
    }
}