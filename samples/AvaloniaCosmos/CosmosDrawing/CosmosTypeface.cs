using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Avalonia.Media;
using Avalonia.Media.Fonts;

namespace AvaloniaCosmos;

internal class CosmosTypeface : IPlatformTypeface
{
    private byte[] _data;

    public CosmosTypeface(ReadOnlySpan<byte> data, FontSimulations fontSimulations)
    {
        _data = data.ToArray();
        FontSimulations = fontSimulations;
    }

    public void Dispose()
    {
    }
    //
    // public bool TryGetTable(OpenTypeTag tag, out ReadOnlyMemory<byte> table)
    // {
    //     table = default;
    //     return false;
    // }

    public bool TryGetStream([NotNullWhen(true)] out Stream? stream)
    {
        stream = new MemoryStream(_data);
        return false;
    }

    public string FamilyName { get; } = "Default";
    public FontWeight Weight { get; } = FontWeight.Normal;
    public FontStyle Style { get; } = FontStyle.Normal;
    public FontStretch Stretch { get; } = FontStretch.Normal;
    public FontSimulations FontSimulations { get; }

    public bool TryGetTable(OpenTypeTag tag, out ReadOnlyMemory<byte> table)
    {
        table = default;

        // Validate tag
        if (tag == new OpenTypeTag(0))
        {
            return false;
        }


        if (_data.Length < 12)
        {
            return false;
        }

        // Create a span over the unmanaged memory (read-only view)
        ReadOnlySpan<byte> fontData = _data;

        // Minimal SFNT header: 4 (sfnt) + 2 (numTables) + 6 (rest) = 12
        if (fontData.Length < 12)
        {
            return false;
        }

        // Check cache first
        // if (_tableCache.TryGetValue(tag, out var cached))
        // {
        //     table = cached;
        //
        //     return true;
        // }

        // Parse table directory
        var numTables = BinaryPrimitives.ReadUInt16BigEndian(fontData.Slice(4, 2));
        var recordsStart = 12;
        var requiredDirectoryBytes = checked(recordsStart + numTables * 16);

        if (fontData.Length < requiredDirectoryBytes)
        {
            return false;
        }

        for (int i = 0; i < numTables; i++)
        {
            var entryOffset = recordsStart + i * 16;
            var entrySlice = fontData.Slice(entryOffset, 16);
            var entryTag = (OpenTypeTag)BinaryPrimitives.ReadUInt32BigEndian(entrySlice.Slice(0, 4));

            if (entryTag != tag)
            {
                continue;
            }

            var offset = BinaryPrimitives.ReadUInt32BigEndian(entrySlice.Slice(8, 4));
            var length = BinaryPrimitives.ReadUInt32BigEndian(entrySlice.Slice(12, 4));

            // Bounds checks - ensure values fit within the span
            if (offset > (uint)fontData.Length || length > (uint)fontData.Length)
            {
                return false;
            }

            if (offset + length > (uint)fontData.Length)
            {
                return false;
            }

            // Safe to cast to int for Slice since we validated bounds
            var memory = fontData.Slice((int)offset, (int)length).ToArray();
            table = memory;
            return true;

            // Acquire write lock to update cache
            // _lock.EnterWriteLock();
            //
            // try
            // {
            //     // Cache the result for faster subsequent lookups
            //     _tableCache[tag] = table;
            //
            //     return true;
            // }
            // finally
            // {
            //     // Release write lock
            //     _lock.ExitWriteLock();
            // }
        }

        return false;
    }
}