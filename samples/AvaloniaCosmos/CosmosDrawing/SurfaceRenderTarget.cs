using System.IO;
using Avalonia;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace AvaloniaCosmos;

internal class SurfaceRenderTarget: IDrawingContextLayerImpl
{
    public SurfaceRenderTarget(CreateInfo createInfo)
    {
        PixelSize = new PixelSize(createInfo.Width, createInfo.Height);
        Dpi = createInfo.Dpi;
    }
    public void Save(Stream stream, BitmapEncoderOptions options)
    {
        throw new System.NotImplementedException();
    }

    public Vector Dpi { get; }
    public PixelSize PixelSize { get; }
    public int Version { get; } = 1;
    public void Blit(IDrawingContextImpl context)
    {
        throw new System.NotImplementedException();
    }

    public IDrawingContextImpl CreateDrawingContext()
    {
        return new CosmosDrawingContextImpl();
    }

    public bool CanBlit { get; } = false;
    public bool IsCorrupted { get; } = false;
    public void Dispose()
    {
    }
    
    
    /// <summary>
    /// Create info of a surface render target.
    /// </summary>
    public struct CreateInfo
    {
        /// <summary>
        /// Width of a render target.
        /// </summary>
        public int Width;

        /// <summary>
        /// Height of a render target.
        /// </summary>
        public int Height;

        /// <summary>
        /// Dpi used when rendering to a surface.
        /// </summary>
        public Vector Dpi;

        /// <summary>
        /// Pixel format of a render target.
        /// </summary>
        public PixelFormat? Format;

        // /// <summary>
        // /// Render text without Lcd rendering.
        // /// </summary>
        // public bool DisableTextLcdRendering;

        // /// <summary>
        // /// GPU-accelerated context (optional)
        // /// </summary>
        // public GRContext? GrContext;
        //
        // public ISkiaGpu? Gpu;
        //
        // public ISkiaGpuRenderSession? Session;

        // public bool DisableManualFbo;
        // public bool UseScaledDrawing;
    }
}
