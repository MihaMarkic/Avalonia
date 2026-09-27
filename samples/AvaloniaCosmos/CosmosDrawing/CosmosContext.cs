using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Platform;
using Avalonia.Platform.Surfaces;

namespace AvaloniaCosmos;

public class CosmosContext: IPlatformRenderInterfaceContext
{
    public object? TryGetFeature(Type featureType)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
    }

    public IRenderTarget CreateRenderTarget(IEnumerable<IPlatformRenderSurface> surfaces)
    {
        if (surfaces is not IList)
        {
            surfaces = surfaces.ToList();
        }
        
        return new CosmosRenderTarget();
    }

    public IDrawingContextLayerImpl CreateOffscreenRenderTarget(PixelSize pixelSize, Vector scaling, bool enableTextAntialiasing)
    {
        throw new NotImplementedException();
    }

    public bool IsLost { get; }
    public IReadOnlyDictionary<Type, object> PublicFeatures { get; } = new Dictionary<Type, object>();
    public PixelSize? MaxOffscreenRenderTargetPixelSize { get; }
}