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

            currentGuestScore = 0;
            currentHomeScore = 0;
            match.HomeScores.Add(currentHomeScore);
            match.GuestScores.Add(currentGuestScore);
            isHomeOnLeft = !isHomeOnLeft;
            UpdateScoreDisplay();

            setsPlayed++;
        }
    }

    private void checkForGameWinner()
    {
        
    }

    private void UpdateScoreDisplay()
    {
        checkForSetWinner();
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
            LeftTeam.Text = match.GuestTeam.Name;
            LeftSetScore.Text = guestWonSets.ToString();
            LeftScore.Text = currentGuestScore.ToString();
            
            RightTeam.Text = match.HomeTeam.Name;
            RightScore.Text = currentHomeScore.ToString();
            RightSetScore.Text = homeWonSets.ToString();
        }
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