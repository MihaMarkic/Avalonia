using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using Avalonia.Media;
using Avalonia.Platform;

namespace AvaloniaCosmos;

public class FontManagerImpl: IFontManagerImpl
{
    private IPlatformTypeface? _defaultTypeface;
    public string GetDefaultFontFamilyName()
    {
        return "Default";
    }

    public string[] GetInstalledFontFamilyNames(bool checkForUpdates = false)
    {
        return ["Default"];
    }

    public bool TryMatchCharacter(int codepoint, FontStyle fontStyle, FontWeight fontWeight, FontStretch fontStretch,
        string? familyName, CultureInfo? culture, [NotNullWhen(true)] out IPlatformTypeface? platformTypeface)
    {
        throw new System.NotImplementedException();
    }

    public bool TryCreateGlyphTypeface(string familyName, FontStyle style, FontWeight weight, FontStretch stretch,
        [NotNullWhen(true)] out IPlatformTypeface? platformTypeface)
    {
        // using var ms = new MemoryStream();
        // stream.CopyTo(ms);
        // var data = ms.ToArray();
        // platformTypeface = new CosmosTypeface(data, fontSimulations);
        platformTypeface  = _defaultTypeface;
        return _defaultTypeface is not null;
    }

    public bool TryCreateGlyphTypeface(Stream stream, FontSimulations fontSimulations, [NotNullWhen(true)] out IPlatformTypeface? platformTypeface)
    {
        using var ms = new MemoryStream();
        stream.CopyTo(ms);
        var data = ms.ToArray();
        platformTypeface = _defaultTypeface = new CosmosTypeface(data, fontSimulations);
        return true;

        return false;
    }

    public bool TryGetFamilyTypefaces(string familyName, [NotNullWhen(true)] out IReadOnlyList<Typeface>? familyTypefaces)
    {
        throw new System.NotImplementedException();
    }
}