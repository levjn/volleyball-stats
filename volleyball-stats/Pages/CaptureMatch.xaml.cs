using volleyball_stats.Entities;

namespace volleyball_stats.Pages;

public partial class CaptureMatch : ContentPage
{
    public Match match;

    private int currentHomeScore;
    private int currentGuestScore;
    private bool isHomeOnLeft = true;
    private int homeWonSets;
    private int guestWonSets;
    private int setsPlayed;

    public CaptureMatch(Guid matchId)
    {
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, false);
        match = Database.Matches.FirstOrDefault(m => m.Id == matchId);

        if (match == null)
        {
            throw new Exception($"Match with ID {matchId} not found.");
        }
        Console.WriteLine(match.HomeScores);
        InitializeComponent();
        UpdateScoreDisplay();
    }

    private void checkForSetWinner()
    {
        var pointsToWinSet = setsPlayed >= 4 ? 15 : 25;
        if (currentHomeScore >= pointsToWinSet && currentHomeScore >= currentGuestScore + 2
            || currentGuestScore >= pointsToWinSet && currentGuestScore >= currentHomeScore + 2)
        {
            if (currentHomeScore > currentGuestScore)
            {
                homeWonSets++;
            }
            else
            {
                guestWonSets++;
            }
            
            match.HomeScores.Add(currentHomeScore);
            match.GuestScores.Add(currentGuestScore);
            currentGuestScore = 0;
            currentHomeScore = 0;
            isHomeOnLeft = !isHomeOnLeft;
            UpdateScoreDisplay();

            setsPlayed++;
            checkForGameWinner();
        }
    }

    private async void checkForGameWinner()
    {
        if (guestWonSets == 3 | homeWonSets == 3)
        {
            await Navigation.PushAsync(new SummaryPage(match.Id));

        }
    }

    private void UpdateScoreDisplay()
    {
        checkForSetWinner();

        // Wenn das Heimteam links ist
        if (isHomeOnLeft)
        {
            LeftTeam.Text = match.HomeTeam.Name;
            LeftScore.Text = currentHomeScore.ToString();
            LeftSetScore.Text = homeWonSets.ToString();

            RightTeam.Text = match.GuestTeam.Name;
            RightScore.Text = currentGuestScore.ToString();
            RightSetScore.Text = guestWonSets.ToString();
        }
        else
        {
            // Wenn das Gastteam links ist
            LeftTeam.Text = match.GuestTeam.Name;
            LeftSetScore.Text = guestWonSets.ToString();
            LeftScore.Text = currentGuestScore.ToString();

            RightTeam.Text = match.HomeTeam.Name;
            RightScore.Text = currentHomeScore.ToString();
            RightSetScore.Text = homeWonSets.ToString();
        }
    }

    
    public void OnSideSwitchToggled(object sender, ToggledEventArgs e)
    {
        isHomeOnLeft = !e.Value; // Wenn der Switch eingeschaltet ist, wechselt die Seite
        UpdateScoreDisplay();
    }

    public void incrementLeftScore(object sender, EventArgs e)
    {
        if (isHomeOnLeft)
        {
            currentHomeScore++;
        }
        else
        {
            currentGuestScore++;
        }
        UpdateScoreDisplay();
    }

    public void decrementLeftScore(object sender, EventArgs e)
    {
        if (isHomeOnLeft && currentHomeScore > 0)
        {
            currentHomeScore--;
        }
        else if (!isHomeOnLeft && currentGuestScore > 0)
        {
            currentGuestScore--;
        }
        UpdateScoreDisplay();
    }

    public void incrementRightScore(object sender, EventArgs e)
    {
        if (isHomeOnLeft)
        {
            currentGuestScore++;
        }
        else
        {
            currentHomeScore++;
        }
        UpdateScoreDisplay();
    }

    public void decrementRightScore(object sender, EventArgs e)
    {
        if (isHomeOnLeft && currentGuestScore > 0)
        {
            currentGuestScore--;
        }
        else if (!isHomeOnLeft && currentHomeScore > 0)
        {
            currentHomeScore--;
        }
        UpdateScoreDisplay();
    }
}