namespace FailSafeProtocol.Domain;

public enum CompositionType
{
    CarbonBased,
    MetalBased,
    SilicateBased
}

public enum IntegrityType
{
    RubblePileSmall,
    RubblePileMedium,
    RubblePileLarge,
    Compact
}

public sealed class Asteroid
{
    public int Velocity { get; }
    public int Size { get; }
    public bool IsFastRotation { get; }
    public bool IsIrregular { get; }
    public CompositionType Composition { get; }
    public bool IsMultiplicity { get; }
    public int Eccentricity { get; }
    public int Volatility { get; }
    public IntegrityType Integrity { get; }
    public int Compact { get; }
    public Country Country { get; }
    public City City { get; }
    public DirectionType Direction { get; }
    public int Brightness { get; }
    public int Mass { get; }
    public int Inertia { get; }
    public int TrajectoryInstability { get; }
    public int Aimability { get; }
    public int Distance { get; private set; }
    public int Population { get; private set; }
    public int DestroyedTerrain { get; private set; }

    public Asteroid(
        int velocity,
        int size,
        bool isFastRotation,
        bool isIrregular,
        CompositionType composition,
        bool isMultiplicity,
        int eccentricity,
        int volatility,
        IntegrityType integrity,
        int compact,
        DirectionType direction,
        Country country,
        City city,
        int population,
        int destroyedTerrain,
        int distance)
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
        Direction = direction;
        Country = country;
        City = city;
        Distance = distance;
        Population = population;
        DestroyedTerrain = destroyedTerrain;

        Brightness = ComputeBrightness();
        Mass = ComputeMass();
        Inertia = ComputeInertia();
        TrajectoryInstability = ComputeTrajectoryInstability();
        Aimability = ComputeAimability();
    }

    private int ComputeBrightness()
    {
        return BrightnessFromComposition(Composition)
             + BrightnessFromIrregularity(IsIrregular)
             + BrightnessFromDirection(Direction)
             + Size
             + BrightnessFromRotation(IsFastRotation);
    }

    private static int BrightnessFromComposition(CompositionType value)
    {
        return value switch
        {
            CompositionType.CarbonBased => -2,
            CompositionType.MetalBased => 1,
            CompositionType.SilicateBased => 3,
            _ => 0
        };
    }

    private static int BrightnessFromDirection(DirectionType value)
    {
        return value switch
        {
            DirectionType.B => -3,
            DirectionType.C => 1,
            _ => 0
        };
    }

    private static int BrightnessFromRotation(bool isFast)
    {
        return isFast ? -2 : 0;
    }

    private static int BrightnessFromIrregularity(bool isIrregular)
    {
        return isIrregular ? -1 : 0;
    }

    private int ComputeMass()
    {
        return (Compact + MassFromComposition(Composition)) * Size;
    }

    private static int MassFromComposition(CompositionType value)
    {
        return value switch
        {
            CompositionType.CarbonBased => 1,
            CompositionType.MetalBased => 3,
            CompositionType.SilicateBased => 2,
            _ => 0
        };
    }

    private int ComputeInertia()
    {
        return Mass * Velocity;
    }

    private int ComputeTrajectoryInstability()
    {
        return InstabilityFromRotation(IsFastRotation)
             + InstabilityFromIrregularity(IsIrregular)
             + Eccentricity
             + Volatility
             + InstabilityFromMultiplicity(IsMultiplicity);
    }

    private static int InstabilityFromRotation(bool isFast)
    {
        return isFast ? 2 : 0;
    }

    private static int InstabilityFromIrregularity(bool isIrregular)
    {
        return isIrregular ? 1 : 0;
    }

    private static int InstabilityFromMultiplicity(bool isMultiple)
    {
        return isMultiple ? 2 : 0;
    }

    private int ComputeAimability()
    {
        return Brightness + Size + Velocity + AimabilityFromMultiplicity(IsMultiplicity);
    }

    private static int AimabilityFromMultiplicity(bool isMultiple)
    {
        return isMultiple ? -2 : 0;
    }

    public void IncreaseDistance()
    {
        Distance++;
    }

    public void setDestroidTerrain(int tearrain)
    {
        DestroyedTerrain = tearrain;
    }

    public void setSurvivors(int survivingPopulation)
    {
        Population = survivingPopulation;
    }
}
    