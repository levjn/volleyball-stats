using Match = volleyball_stats.Entities.Match;

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

        // Initialize with the initial number of fields
        for (int i = 0; i < InitialFields; i++)
        {
            AddEntryField(null, null);
        }
    }

    public void setHomeName()
    {
        homeNameLabel.Text = $"Heimteam: {match.HomeTeam.Name}";
    }

    // Add an entry field to the container
    private void AddEntryField(object sender, EventArgs e)
    {
        if (entryContainer.Children.Count >= MaxFields)
        {
            DisplayAlert("Limit erreicht", $"Maximale Anzahl von {MaxFields} Feldern erreicht.", "OK");
            return;
        }

        var entry = new Entry
        {
            Placeholder = $"Spieler {entryContainer.Children.Count + 1}"
        };

        entryContainer.Children.Add(entry);
    }

    // Remove the last entry field from the container
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

    // Get the text from all entry fields
    public List<string> GetPlayerNames()
    {
        return entryContainer.Children
                             .OfType<Entry>()
                             .Select(entry => entry.Text)
                             .Where(text => !string.IsNullOrWhiteSpace(text)) // Ignore empty fields
                             .ToList();
    }
}
