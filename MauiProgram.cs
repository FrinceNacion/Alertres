using Microsoft.Extensions.Logging;
using Alertres.ApiClient.IoC;

namespace AlertresVer2
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
            var baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5112/" : "http://localhost:5112/";
            builder.Services.AddAlertresApiClientService(x => x.ApiBaseAddress = "http://192.168.100.126:5112/");
            builder.Services.AddTransient<MainPage> ();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
