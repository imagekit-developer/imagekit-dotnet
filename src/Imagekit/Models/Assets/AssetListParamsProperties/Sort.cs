using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Imagekit.Models.Assets.AssetListParamsProperties;

/// <summary>
/// Sort the results by one of the supported fields in ascending or descending order.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    AscName,
    DescName,
    AscCreated,
    DescCreated,
    AscUpdated,
    DescUpdated,
    AscHeight,
    DescHeight,
    AscWidth,
    DescWidth,
    AscSize,
    DescSize,
    AscRelevance,
    DescRelevance,
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ASC_NAME" => Sort.AscName,
            "DESC_NAME" => Sort.DescName,
            "ASC_CREATED" => Sort.AscCreated,
            "DESC_CREATED" => Sort.DescCreated,
            "ASC_UPDATED" => Sort.AscUpdated,
            "DESC_UPDATED" => Sort.DescUpdated,
            "ASC_HEIGHT" => Sort.AscHeight,
            "DESC_HEIGHT" => Sort.DescHeight,
            "ASC_WIDTH" => Sort.AscWidth,
            "DESC_WIDTH" => Sort.DescWidth,
            "ASC_SIZE" => Sort.AscSize,
            "DESC_SIZE" => Sort.DescSize,
            "ASC_RELEVANCE" => Sort.AscRelevance,
            "DESC_RELEVANCE" => Sort.DescRelevance,
            _ => (Sort)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Sort value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Sort.AscName => "ASC_NAME",
                Sort.DescName => "DESC_NAME",
                Sort.AscCreated => "ASC_CREATED",
                Sort.DescCreated => "DESC_CREATED",
                Sort.AscUpdated => "ASC_UPDATED",
                Sort.DescUpdated => "DESC_UPDATED",
                Sort.AscHeight => "ASC_HEIGHT",
                Sort.DescHeight => "DESC_HEIGHT",
                Sort.AscWidth => "ASC_WIDTH",
                Sort.DescWidth => "DESC_WIDTH",
                Sort.AscSize => "ASC_SIZE",
                Sort.DescSize => "DESC_SIZE",
                Sort.AscRelevance => "ASC_RELEVANCE",
                Sort.DescRelevance => "DESC_RELEVANCE",
                _ => throw new System::ArgumentOutOfRangeException(nameof(value)),
            },
            options
        );
    }
}
