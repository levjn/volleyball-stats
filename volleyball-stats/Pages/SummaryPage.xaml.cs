using volleyball_stats.Entities;

namespace volleyball_stats.Pages;

public partial class SummaryPage : ContentPage
{
    private Match match;

    public SummaryPage(Guid matchId)
    {
        InitializeComponent();
        NavigationPage.SetHasBackButton(this, false);

        match = Database.Matches.FirstOrDefault(m => m.Id == matchId);

        if (match == null)
        {
            throw new Exception($"Match with ID {matchId} not found.");
        }

        homeName.Text = match.HomeTeam.Name;
        guestName.Text = match.GuestTeam.Name;

        int homeSetsWon = 0;
        int guestSetsWon = 0;

        for (int i = 0; i < match.HomeScores.Count; i++)
        {
            if (match.HomeScores[i] > match.GuestScores[i])
            {
                homeSetsWon++;
            }
            else if (match.GuestScores[i] > match.HomeScores[i])
            {
                guestSetsWon++;
            }
        }

        homeSetScore.Text = homeSetsWon.ToString();
        guestSetScore.Text = guestSetsWon.ToString();

        homeScoresList.ItemsSource = match.HomeScores;
        guestScoresList.ItemsSource = match.GuestScores;
    }
}