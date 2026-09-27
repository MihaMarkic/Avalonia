using Avalonia;
using Avalonia.Platform;

namespace AvaloniaCosmos;

public static class CosmosPlatform
{
    public static void Initialize()
    {
        var renderInterface = new PlatformRenderInterface();

        AvaloniaLocator.CurrentMutable
            .Bind<IPlatformRenderInterface>().ToConstant(renderInterface)
            .Bind<IFontManagerImpl>().ToConstant(new FontManagerImpl());
    }
}
