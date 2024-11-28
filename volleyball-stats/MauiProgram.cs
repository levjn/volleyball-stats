using Microsoft.Extensions.Logging;
using volleyball_stats.Data.Entities;
using volleyball_stats.Data.Services;

namespace volleyball_stats
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<BaseDbService<MatchDbEntity>>();
            builder.Services.AddSingleton<BaseDbService<PlayerDbEntity>>();
            builder.Services.AddSingleton<BaseDbService<TeamDbEntity>>();
            builder.Services.AddSingleton<BaseDbService<Player_Match_Points>>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
