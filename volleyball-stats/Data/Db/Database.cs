using volleyball_stats.Entities;

public class Database
{
    private static Database _instance;
    private static readonly object _lock = new object();

    public static  List<Match> Matches { get; set; } = new();
    public static List<Team> Teams { get; set; } = new();
    public static List<Player> Players { get; set; } = new();



    private Database() { }

    public static Database Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Database();

                return _instance;
            }
        }
    }
}