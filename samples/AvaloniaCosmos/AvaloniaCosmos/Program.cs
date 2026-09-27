using Avalonia;
using System;
using CosmosFrameBuffer;

namespace AvaloniaCosmos;

static class Program
{
	[STAThread]
	public static int Main(string[] args)
	{
		var builder = BuildAvaloniaApp();
		return builder.StartCosmosDirect(args);
	}

	
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    // [STAThread]
    // public static void Main(string[] args) => BuildAvaloniaApp()
    //     .StartWithClassicDesktopLifetime(args);
    //
    // // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
	    => AppBuilder.Configure<App>()
		    .UseHarfBuzz();
    //   .StartCosmosDirect(args);
#if DEBUG
    // .WithDeveloperTools()
#endif
    // .WithInterFont()
    // .LogToTrace();
}