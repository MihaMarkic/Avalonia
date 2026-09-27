using System;
using Avalonia.Platform;

namespace AvaloniaCosmos;

internal class CosmosRenderTarget : IRenderTarget
{
    public RenderTargetProperties Properties { get; }

    public IDrawingContextImpl CreateDrawingContext(IRenderTarget.RenderTargetSceneInfo sceneInfo,
        out RenderTargetDrawingContextProperties properties)
    {
        properties = default;
        // var session = _renderTarget.BeginRenderingSession(sceneInfo);
        //
        // var nfo = new DrawingContextImpl.CreateInfo
        // {
        //     GrContext = session.GrContext,
        //     Surface = session.SkSurface,
        //     Dpi = SkiaPlatform.DefaultDpi * session.ScaleFactor,
        //     ScaleDrawingToDpi = false,
        //     Gpu = _skiaGpu,
        //     CurrentSession =  session
        // };

        return new CosmosDrawingContextImpl();
    }

    public void Dispose()
    {
    }
}