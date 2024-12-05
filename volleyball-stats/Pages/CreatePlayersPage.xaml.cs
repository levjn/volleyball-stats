namespace volleyball_stats.Pages;

public partial class CreatePlayersPage : ContentPage
{
    public string getHomeName()
    {
        return Database.Matches[0].HomeTeam.Name;
    }
    public CreatePlayersPage()
    {
        InitializeComponent();
    }
}