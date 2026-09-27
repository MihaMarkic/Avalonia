using System.Buffers;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.TextFormatting;
using Avalonia.Platform;
using AvaloniaCosmos.Imaginary;

namespace AvaloniaCosmos;

internal class GlyphRunImpl : IGlyphRunImpl
{
    private readonly CosmosTypeface _glyphTypefaceImpl;
    private readonly ushort[] _glyphIndices;
    // private readonly SKPoint[] _glyphPositions;

    public GlyphRunImpl(GlyphTypeface? glyphTypeface, double fontRenderingEmSize,
        IReadOnlyList<GlyphInfo> glyphInfos, Point baselineOrigin)
    {
        // if (glyphTypeface == null)
        // {
        //     throw new ArgumentNullException(nameof(glyphTypeface));
        // }
        //
        // if (glyphInfos == null)
        // {
        //     throw new ArgumentNullException(nameof(glyphInfos));
        // }
        //
        // _glyphTypefaceImpl = (CosmosTypeface)glyphTypeface.PlatformTypeface;
        // FontRenderingEmSize = fontRenderingEmSize;
        //
        // var count = glyphInfos.Count;
        // _glyphIndices = new ushort[count];
        // // _glyphPositions = new SKPoint[count];
        //
        // // GetGlyphWidths needs _glyphIndices populated before the
        // // per-glyph bounds can be fetched, so this walk has to come
        // // first. It deliberately does no other work — positions and
        // // runBounds are built together in the fused walk below, using
        // // a single currentX accumulator.
        // for (int i = 0; i < count; i++)
        // {
        //     _glyphIndices[i] = glyphInfos[i].GlyphIndex;
        // }
        //
        // // Ideally the requested edging should be passed to the glyph run.
        // // Currently, the edging is computed dynamically inside the drawing context, so we can't know it in advance.
        // // But the bounds depends on the edging: for now, always use SubpixelAntialias so we have consistent values.
        // // The resulting bounds may be shifted by 1px on some fonts:
        // // "F" text with Inter size 14 has a 0px left bound with SubpixelAntialias but 1px with Antialias.
        // var defaultTextOptions = default(TextOptions) with
        // {
        //     TextRenderingMode = TextRenderingMode.SubpixelAntialias,
        //     TextHintingMode = TextHintingMode.Strong,
        //     BaselinePixelAlignment = BaselinePixelAlignment.Unaligned
        // };
        //
        // using var font = CreateFont(defaultTextOptions);
        //
        // var glyphBounds = ArrayPool<CosmosRect>.Shared.Rent(count);
        //
        // try
        // {
        //     font.GetGlyphWidths(_glyphIndices, null, glyphBounds.AsSpan(0, count));
        //
        //     // build _glyphPositions and union runBounds in a
        //     // single pass. Replaces the previous two separate walks (each
        //     // maintaining its own currentX) each glyphInfo is read once,
        //     // and one accumulator covers both outputs.
        //     var currentX = 0.0;
        //     var runBounds = new Rect();
        //
        //     for (int i = 0; i < count; i++)
        //     {
        //         var glyphInfo = glyphInfos[i];
        //         var offset = glyphInfo.GlyphOffset;
        //         var gBounds = glyphBounds[i];
        //
        //         _glyphPositions[i] = new SKPoint((float)(currentX + offset.X), (float)offset.Y);
        //
        //         // runBounds = runBounds.Union(new Rect(currentX + gBounds.Left, gBounds.Top, gBounds.Width,
        //         //     gBounds.Height));
        //
        //         currentX += glyphInfo.GlyphAdvance;
        //     }
        //
        //     BaselineOrigin = baselineOrigin;
        //     Bounds = runBounds.Translate(new Vector(baselineOrigin.X, baselineOrigin.Y));
        // }
        // finally
        // {
        //     ArrayPool<CosmosRect>.Shared.Return(glyphBounds);
        // }
    }

    private Font CreateFont(TextOptions defaultTextOptions) => new Font();

    public IReadOnlyList<float> GetIntersections(float lowerLimit, float upperLimit)
    {
        throw new NotImplementedException();
    }

    public double FontRenderingEmSize { get; }
    public Point BaselineOrigin { get; }
    public Rect Bounds { get; }

    public void Dispose()
    {
    }
}