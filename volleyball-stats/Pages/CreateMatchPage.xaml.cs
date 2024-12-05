using System.Text.RegularExpressions;
using volleyball_stats.Entities;
using Match = volleyball_stats.Entities.Match;

namespace volleyball_stats.Pages;

public partial class CreateMatchPage : ContentPage
{
	public CreateMatchPage()
	{
		InitializeComponent();
		
	}

	public async void navigateToCreatePlayers(object? sender, EventArgs eventArgs)
	{
		var homeTeam = new Team()
		{
			Name = homeEntry.Text
		};
		
		var guestTeam = new Team()
		{
			Name = guestEntry.Text
		};
		Match match = new()
		{
			HomeTeam = homeTeam,
			GuestTeam = guestTeam,
			PlayDateTime = DateTime.Now
		};
		
		Database.Matches.Add(match);
		
		await Navigation.PushAsync(new CreatePlayersPage());
	}
	
	
}