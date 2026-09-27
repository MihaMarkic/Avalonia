using System;
using System.Diagnostics;
using Avalonia;
using Avalonia.Media;
using Avalonia.Platform;

namespace AvaloniaCosmos;

internal class CosmosDrawingContextImpl: IDrawingContextImpl
    // IDrawingContextWithAcrylicLikeSupport,
    // IDrawingContextImplWithEffects
{

    public void Clear(Color color)
    {
        Debug.WriteLine("CosmosDrawingContext.Clear");
    }

    public void DrawBitmap(IBitmapImpl source, double opacity, Rect sourceRect, Rect destRect)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawBitmap");
    }

    public void DrawBitmap(IBitmapImpl source, IBrush opacityMask, Rect opacityMaskRect, Rect destRect)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawBitmap");
    }

    public void DrawLine(IPen? pen, Point p1, Point p2)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawLine");
    }

    public void DrawGeometry(IBrush? brush, IPen? pen, IGeometryImpl geometry)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawGeometry");
    }

    public void DrawRectangle(IBrush? brush, IPen? pen, RoundedRect rect, BoxShadows boxShadows = new BoxShadows())
    {
        Debug.WriteLine("CosmosDrawingContext.DrawRectangle");
    }

    public void DrawRegion(IBrush? brush, IPen? pen, IPlatformRenderInterfaceRegion region)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawRegion");
    }

    public void DrawEllipse(IBrush? brush, IPen? pen, Rect rect)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawEllipse");
    }

    public void DrawGlyphRun(IBrush? foreground, IGlyphRunImpl glyphRun)
    {
        Debug.WriteLine("CosmosDrawingContext.DrawGlyphRun");
    }

    public IDrawingContextLayerImpl CreateLayer(PixelSize size)
    {
        Debug.WriteLine("CosmosDrawingContext.CreateLayer");
        var createInfo = new SurfaceRenderTarget.CreateInfo
        {
            Width = size.Width,
            Height = size.Height,
            Dpi = new Vector(96.0, 96.0),
            Format = null,
        };

        return new SurfaceRenderTarget(createInfo);
    }

    public void PushClip(Rect clip)
    {
        Debug.WriteLine("CosmosDrawingContext.PushClip");
    }

    public void PushClip(RoundedRect clip)
    {
        Debug.WriteLine("CosmosDrawingContext.PushClip");
    }

    public void PushClip(IPlatformRenderInterfaceRegion region)
    {
        Debug.WriteLine("CosmosDrawingContext.PushClip");
    }

    public void PopClip()
    {
        Debug.WriteLine("CosmosDrawingContext.PopClip");
    }

    public void PushLayer(Rect bounds)
    {
        Debug.WriteLine("CosmosDrawingContext.PushLayer");
    }

    public void PopLayer()
    {
        Debug.WriteLine("CosmosDrawingContext.PopLayer");
    }

    public void PushOpacity(double opacity, Rect? bounds)
    {
        Debug.WriteLine("CosmosDrawingContext.PushOpacity");
    }

    public void PopOpacity()
    {
        Debug.WriteLine("CosmosDrawingContext.PopOpacity");
    }

    public void PushOpacityMask(IBrush mask, Rect bounds)
    {
        Debug.WriteLine("CosmosDrawingContext.PushOpacityMask");
    }

    public void PopOpacityMask()
    {
        Debug.WriteLine("CosmosDrawingContext.PopOpacityMask");
    }

    public void PushGeometryClip(IGeometryImpl clip)
    {
        Debug.WriteLine("CosmosDrawingContext.PushGeometryClip");
    }

    public void PopGeometryClip()
    {
        Debug.WriteLine("CosmosDrawingContext.PopGeometryClip");
    }

    public void PushRenderOptions(RenderOptions renderOptions)
    {
        Debug.WriteLine("CosmosDrawingContext.PushRenderOptions");
    }

    public void PopRenderOptions()
    {
        Debug.WriteLine("CosmosDrawingContext.PopRenderOptions");
    }

    public void PushTextOptions(TextOptions textOptions)
    {
        Debug.WriteLine("CosmosDrawingContext.PushTextOptions");
    }

    public void PopTextOptions()
    {
        Debug.WriteLine("CosmosDrawingContext.PopTextOptions");
    }

    public object? GetFeature(Type t)
    {
        Debug.WriteLine("CosmosDrawingContext.GetFeature");
        throw new NotImplementedException();
    }

    public Matrix Transform { get; set; }
    
    public void Dispose()
    {
    }

}