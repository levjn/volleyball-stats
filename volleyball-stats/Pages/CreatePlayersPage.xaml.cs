using volleyball_stats.Entities;

namespace volleyball_stats.Pages;

public partial class CreatePlayersPage : ContentPage
{
    private const int MaxFields = 14;  // Maximum number of fields
    private const int InitialFields = 6;  // Initial number of fields
    private Match match;

    public CreatePlayersPage(Guid matchId)
    {
        NavigationPage.SetHasBackButton(this, false);
        InitializeComponent();
        match = Database.Matches.FirstOrDefault(m => m.Id == matchId);

        if (match == null)
        {
            throw new Exception($"Match with ID {matchId} not found.");
        }

        setHomeName();

        for (int i = 0; i < InitialFields; i++)
        {
            AddEntryField(null, null);
        }
    }

    public void setHomeName()
    {
        homeNameLabel.Text = $"Heimteam: {match.HomeTeam.Name}";
    }

    private void AddEntryField(object sender, EventArgs e)
    {
        if (entryContainer.Children.Count >= MaxFields)
        {
            DisplayAlert("Limit erreicht", $"Maximale Anzahl von {MaxFields} Feldern erreicht.", "OK");
            return;
        }

        var playerEntryLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Spacing = 10
        };

        var numberEntry = new Entry
        {
            Placeholder = "Nummer",
            Keyboard = Keyboard.Numeric,
            WidthRequest = 60
        };

        var nameEntry = new Entry
        {
            Placeholder = $"Spieler {entryContainer.Children.Count / 2 + 1}",
            HorizontalOptions = LayoutOptions.FillAndExpand
        };

        playerEntryLayout.Children.Add(numberEntry);
        playerEntryLayout.Children.Add(nameEntry);

        entryContainer.Children.Add(playerEntryLayout);
    }

    private void RemoveEntryField(object sender, EventArgs e)
    {
        if (entryContainer.Children.Count > 0)
        {
            entryContainer.Children.RemoveAt(entryContainer.Children.Count - 1);
        }
        else
        {
            DisplayAlert("Keine Felder", "Es gibt keine Felder zum Entfernen.", "OK");
        }
    }

    public List<(int number, string? name)> GetPlayerDetails()
    {
        return entryContainer.Children
                             .OfType<StackLayout>()
                             .Select(layout =>
                             {
                                 var numberEntry = layout.Children[0] as Entry;
                                 var nameEntry = layout.Children[1] as Entry;

                                 int.TryParse(numberEntry?.Text, out int number);
                                 var name = nameEntry?.Text;

                                 return (number, name);
                             })
                             .Where(details => details.Item2 != null && !string.IsNullOrWhiteSpace(details.Item2))
                             .ToList();
    }

    private async void OnFertigButtonClicked(object sender, EventArgs e)
    {
        var playerDetails = GetPlayerDetails();

        foreach (var (playerNumber, playerName) in playerDetails)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                PlayerNumber = playerNumber,
                Name = playerName,
                Team = match.HomeTeam
            };

            Database.Players.Add(player);
        }
        
        await Navigation.PushAsync(new CaptureMatch(match));
    }
}
