namespace FailSafeProtocol.Domain;

public sealed class AsteroidDto
{
    public int? Velocity { get; }
    public int? Size { get; }
    public bool? IsFastRotation { get; }
    public bool? IsIrregular { get; }
    public CompositionType? Composition { get; }
    public bool? IsMultiplicity { get; }
    public int? Eccentricity { get; }
    public int? Volatility { get; }
    public IntegrityType? Integrity { get; }
    public int? Compact { get; }
    public string? Country { get; }
    public string? City { get; }
    public int? Population { get; }
    public int? DesviationProbability { get; }
    public int? DestroyedTerrain { get; }
    public int Distance { get; }

    public AsteroidDto(
        int? velocity = null,
        int? size = null,
        bool? isFastRotation = null,
        bool? isIrregular = null,
        CompositionType? composition = null,
        bool? isMultiplicity = null,
        int? eccentricity = null,
        int? volatility = null,
        IntegrityType? integrity = null,
        int? compact = null,
        string? country = null,
        string? city = null,
        int? population = null,
        int? desviationProbability = null,
        int? destroyedTerrain = null,
        int distance = 1)
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
        Country = country;
        City = city;
        Population = population;
        DesviationProbability = desviationProbability;
        DestroyedTerrain = destroyedTerrain;
        Distance = distance;
    }
}
