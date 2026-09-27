using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Media.TextFormatting;
using Avalonia.Platform;

namespace AvaloniaCosmos;

internal class PlatformRenderInterface: IPlatformRenderInterface
{
    public IGeometryImpl CreateEllipseGeometry(Rect rect)
    {
        throw new NotImplementedException();
    }

    public IGeometryImpl CreateLineGeometry(Point p1, Point p2)
    {
        throw new NotImplementedException();
    }

    public IGeometryImpl CreateRectangleGeometry(Rect rect)
    {
        throw new NotImplementedException();
    }

    public IStreamGeometryImpl CreateStreamGeometry()
    {
        throw new NotImplementedException();
    }

    public IGeometryImpl CreateGeometryGroup(FillRule fillRule, IReadOnlyList<IGeometryImpl> children)
    {
        throw new NotImplementedException();
    }

    public IGeometryImpl CreateCombinedGeometry(GeometryCombineMode combineMode, IGeometryImpl g1, IGeometryImpl g2)
    {
        throw new NotImplementedException();
    }

    public IGeometryImpl BuildGlyphRunGeometry(GlyphRun glyphRun)
    {
        throw new NotImplementedException();
    }

    public IRenderTargetBitmapImpl CreateRenderTargetBitmap(PixelSize size, Vector dpi)
    {
        throw new NotImplementedException();
    }

    public IWriteableBitmapImpl CreateWriteableBitmap(PixelSize size, Vector dpi, PixelFormat format, AlphaFormat alphaFormat)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl LoadBitmap(string fileName)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl LoadBitmap(Stream stream)
    {
        throw new NotImplementedException();
    }

    public IWriteableBitmapImpl LoadWriteableBitmapToWidth(Stream stream, int width,
        BitmapInterpolationMode interpolationMode = BitmapInterpolationMode.HighQuality)
    {
        throw new NotImplementedException();
    }

    public IWriteableBitmapImpl LoadWriteableBitmapToHeight(Stream stream, int height,
        BitmapInterpolationMode interpolationMode = BitmapInterpolationMode.HighQuality)
    {
        throw new NotImplementedException();
    }

    public IWriteableBitmapImpl LoadWriteableBitmap(string fileName)
    {
        throw new NotImplementedException();
    }

    public IWriteableBitmapImpl LoadWriteableBitmap(Stream stream)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl LoadBitmapToWidth(Stream stream, int width, BitmapInterpolationMode interpolationMode = BitmapInterpolationMode.HighQuality)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl LoadBitmapToHeight(Stream stream, int height, BitmapInterpolationMode interpolationMode = BitmapInterpolationMode.HighQuality)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl ResizeBitmap(IBitmapImpl bitmapImpl, PixelSize destinationSize,
        BitmapInterpolationMode interpolationMode = BitmapInterpolationMode.HighQuality)
    {
        throw new NotImplementedException();
    }

    public IBitmapImpl LoadBitmap(PixelFormat format, AlphaFormat alphaFormat, IntPtr data, PixelSize size, Vector dpi,
        int stride)
    {
        throw new NotImplementedException();
    }

    public IGlyphRunImpl CreateGlyphRun(GlyphTypeface glyphTypeface, double fontRenderingEmSize, IReadOnlyList<GlyphInfo> glyphInfos,
        Point baselineOrigin)
    {
        return new GlyphRunImpl(glyphTypeface, fontRenderingEmSize, glyphInfos, baselineOrigin);
    }

    public IPlatformRenderInterfaceContext CreateBackendContext(IPlatformGraphicsContext? graphicsApiContext)
    {
	    Console.WriteLine("CreateBackendContext");
        return new CosmosContext();
    }

    public bool IsSupportedBitmapPixelFormat(PixelFormat format)
    {
        throw new NotImplementedException();
    }

    public IPlatformRenderInterfaceRegion CreateRegion()
    {
        throw new NotImplementedException();
    }

    public bool SupportsIndividualRoundRects { get; }
    public AlphaFormat DefaultAlphaFormat { get; }
    public PixelFormat DefaultPixelFormat { get; }
    public bool SupportsRegions { get; }
}