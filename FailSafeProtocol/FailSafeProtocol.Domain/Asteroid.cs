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
    public int Velocity { get; init; }
    public int Size { get; init; }
    public bool IsFastRotation { get; init; }
    public bool IsIrregular { get; init; }
    public CompositionType Composition { get; init; }
    public bool IsMultiplicity { get; init; }
    public int Eccentricity { get; init; }
    public int Volatility { get; init; }
    public IntegrityType Integrity { get; init; }
    public int Compact { get; init; }
    public DirectionType Direction { get; init; }
    public int Brightness { get; init; }
    public int Mass { get; init; }
    public int Inertia { get; init; }
    public int TrajectoryInstability { get; init; }
    public int Aimability { get; init; }

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
        DirectionType direction)
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
        return Compact + MassFromComposition(Composition) + Size;
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
}
    