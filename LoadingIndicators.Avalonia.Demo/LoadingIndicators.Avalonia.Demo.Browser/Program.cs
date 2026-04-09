using Avalonia;
using Avalonia.Browser;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: SupportedOSPlatform("browser")]

namespace LoadingIndicators.Avalonia.Demo.Browser;

internal static partial class Program
{
    private static Task Main(string[] args) =>
        BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");

    private static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>();
}