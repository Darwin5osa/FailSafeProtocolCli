namespace FailSafeProtocol.Domain;

public sealed class AsteroidDto
{
    public int? Velocity { get; init; }
    public int? Size { get; init; }
    public bool? IsFastRotation { get; init; }
    public bool? IsIrregular { get; init; }
    public CompositionType? Composition { get; init; }
    public bool? IsMultiplicity { get; init; }
    public int? Eccentricity { get; init; }
    public int? Volatility { get; init; }
    public IntegrityType? Integrity { get; init; }
    public int? Compact { get; init; }

    public AsteroidDto(
        int? velocity,
        int? size,
        bool? isFastRotation,
        bool? isIrregular,
        CompositionType? composition,
        bool? isMultiplicity,
        int? eccentricity, 
        int? volatility,
        IntegrityType? integrity,
        int? compact)
    {
        Velocity = velocity;
        Size = size;
        IsFastRotation = isFastRotation;
        IsIrregular = isIrregular;
        Composition = composition;
        IsMultiplicity = isMultiplicity;
        Eccentricity = eccentricity;
        Volatility = volatility;
        Integrity = integrity;
        Compact = compact;
    }
}
