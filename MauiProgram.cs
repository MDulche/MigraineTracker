using Microsoft.Extensions.Logging;
using MigraineTracker.Services;
using MigraineTracker.ViewModels;
using MigraineTracker.Views;

namespace MigraineTracker
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<DatabaseServices>();
            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddTransient<HistoryViewModel>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<CalendarViewModel>();
            builder.Services.AddTransient<CalendarPage>();
            builder.Services.AddTransient<StatsPage>();
            builder.Services.AddTransient<NewMigraineViewModel>();
            builder.Services.AddTransient<NewMigraine>();

            return builder.Build();
        }
    }
}
