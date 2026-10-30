using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Imagekit.Core;

namespace Imagekit.Models.Accounts.Contract;

[JsonConverter(typeof(JsonModelConverter<ContractGetResponse, ContractGetResponseFromRaw>))]
public sealed record class ContractGetResponse : JsonModel
{
    /// <summary>
    /// Whether the account has an active contract. The other fields are present
    /// only when it does.
    /// </summary>
    public required bool HasContract
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("hasContract");
        }
        init { this._rawData.Set("hasContract", value); }
    }

    /// <summary>
    /// When `consumed` was last computed. `null` if it has not been computed for
    /// the contract yet; `consumed` is then all zeros.
    /// </summary>
    public DateTimeOffset? AsOf
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("asOf");
        }
        init { this._rawData.Set("asOf", value); }
    }

    /// <summary>
    /// Usage consumed in the current contract term. For an agency account, this
    /// includes the child accounts billed to it.
    /// </summary>
    public ContractUnits? Consumed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractUnits>("consumed");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("consumed", value);
        }
    }

    /// <summary>
    /// Length of each contract term in months.
    /// </summary>
    public long? ContractMonths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("contractMonths");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contractMonths", value);
        }
    }

    /// <summary>
    /// End date of the current contract term.
    /// </summary>
    public string? EffectiveContractEndDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("effectiveContractEndDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effectiveContractEndDate", value);
        }
    }

    /// <summary>
    /// Start date of the current contract term. It moves forward when the contract renews.
    /// </summary>
    public string? EffectiveContractStartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("effectiveContractStartDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("effectiveContractStartDate", value);
        }
    }

    /// <summary>
    /// Start date of the first contract term.
    /// </summary>
    public string? OriginalContractStartDate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("originalContractStartDate");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("originalContractStartDate", value);
        }
    }

    /// <summary>
    /// Usage included in the current contract term.
    /// </summary>
    public ContractUnits? Quota
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ContractUnits>("quota");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("quota", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.HasContract;
        _ = this.AsOf;
        this.Consumed?.Validate();
        _ = this.ContractMonths;
        _ = this.EffectiveContractEndDate;
        _ = this.EffectiveContractStartDate;
        _ = this.OriginalContractStartDate;
        this.Quota?.Validate();
    }

    public ContractGetResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContractGetResponse(ContractGetResponse contractGetResponse)
        : base(contractGetResponse) { }
#pragma warning restore CS8618

    public ContractGetResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContractGetResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContractGetResponseFromRaw.FromRawUnchecked"/>
    public static ContractGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ContractGetResponse(bool hasContract)
        : this()
    {
        this.HasContract = hasContract;
    }
}

class ContractGetResponseFromRaw : IFromRawJson<ContractGetResponse>
{
    /// <inheritdoc/>
    public ContractGetResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContractGetResponse.FromRawUnchecked(rawData);
}
