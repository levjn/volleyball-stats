using volleyball_stats.Entities;

namespace volleyball_stats.Pages;

public partial class CaptureMatch : ContentPage
{
    public Match match;
    public CaptureMatch(Match match)
    {
        this.match = match;
        InitializeComponent();
        LeftScore.Text = match.HomeTeam.Name;
        RightScore.Text = match.GuestTeam.Name;
    }
}