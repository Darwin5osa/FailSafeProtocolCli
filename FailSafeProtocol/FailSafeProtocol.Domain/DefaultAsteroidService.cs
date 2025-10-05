namespace FailSafeProtocol.Domain;

public sealed class DefaultAsteroidService : AsteroidService
{
    private const int QUADRANT_COUNT = 4;

    private const int DIFFICULTY_ROUND_CAP = 10;
    private const double DIFFICULTY_SCALE = 10.0;

    private const int MIN_VELOCITY_VALUE = 1;
    private const int MAX_VELOCITY_VALUE = 5;
    private const int MIN_SIZE_VALUE = 1;
    private const int MAX_SIZE_VALUE = 5;
    private const int MIN_ECCENTRICITY_VALUE = 1;
    private const int MAX_ECCENTRICITY_VALUE = 5;
    private const int MIN_VOLATILITY_VALUE = 1;
    private const int MAX_VOLATILITY_VALUE = 3;
    private const int MIN_COMPACT_VALUE = 1;
    private const int MAX_COMPACT_VALUE = 5;

    private const int VELOCITY_MAX_INCREMENT_AT_FULL_DIFFICULTY = 3;
    private const int SIZE_MAX_DECREMENT_AT_FULL_DIFFICULTY = 3;
    private const int ECCENTRICITY_MAX_INCREMENT_AT_FULL_DIFFICULTY = 2;
    private const int VOLATILITY_MAX_INCREMENT_AT_FULL_DIFFICULTY = 1;
    private const int COMPACT_MAX_INCREMENT_AT_FULL_DIFFICULTY = 3;

    private const double FAST_ROTATION_BASE_PROBABILITY = 0.4;
    private const double FAST_ROTATION_DIFFICULTY_SLOPE = 0.5;
    private const double IRREGULAR_BASE_PROBABILITY = 0.3;
    private const double IRREGULAR_DIFFICULTY_SLOPE = 0.5;
    private const double MULTIPLICITY_BASE_PROBABILITY = 0.2;
    private const double MULTIPLICITY_DIFFICULTY_SLOPE = 0.6;

    private const double METAL_BASE_PROBABILITY = 0.4;
    private const double METAL_DIFFICULTY_SLOPE = 0.4;
    private const double SILICATE_BASE_PROBABILITY = 0.3;
    private const double SILICATE_DIFFICULTY_SLOPE = -0.1;

    private const double PROBABILITY_DIRECTION_A = 0.30;
    private const double PROBABILITY_DIRECTION_B = 0.10;
    private const double PROBABILITY_DIRECTION_C = 0.30;
    //private const double PROBABILITY_DIRECTION_D = 0.30;

    // TODO modify levels of brightness ---------------------
    private const int BRIGHTNESS_LEVEL_NONE_MAX = 0;
    private const int BRIGHTNESS_LEVEL_BASIC_MAX = 3;
    private const int BRIGHTNESS_LEVEL_INTERMEDIATE_MAX = 6;
    // ------------------------------------------------------

    private readonly System.Random random = new System.Random();
    private readonly Asteroid?[] activeAsteroids = new Asteroid?[QUADRANT_COUNT];

    public AsteroidDto?[] GetAsteroid(int roundNumber)
    {
        int quadrantIndex = SelectQuadrantIndex();
        var direction = DirectionFromIndex(quadrantIndex);
        var asteroid = GenerateAsteroid(roundNumber, direction);
        activeAsteroids[quadrantIndex] = asteroid;
        return MapStoreToDtos();
    }

    public AsteroidDto?[] CalculateStates(string?[] actions)
    {
        for (int index = 0; index < QUADRANT_COUNT; index++)
        {
            string? action = index < actions.Length ? actions[index] : null;
            activeAsteroids[index] = ApplyAction(activeAsteroids[index], action);
        }
        return MapStoreToDtos();
    }

    private int SelectQuadrantIndex()
    {
        while (true)
        {
            double roll = random.NextDouble();
            int candidate = roll < PROBABILITY_DIRECTION_A
                ? 0
                : roll < PROBABILITY_DIRECTION_A + PROBABILITY_DIRECTION_B
                    ? 1
                    : roll < PROBABILITY_DIRECTION_A + PROBABILITY_DIRECTION_B + PROBABILITY_DIRECTION_C
                        ? 2
                        : 3;

            if (activeAsteroids[candidate] is null) return candidate;
        }
    }

    private static DirectionType DirectionFromIndex(int index)
    {
        return index switch
        {
            0 => DirectionType.A,
            1 => DirectionType.B,
            2 => DirectionType.C,
            _ => DirectionType.D
        };
    }

    private Asteroid? ApplyAction(Asteroid? current, string? action)
    {
        if (current is null) return null;
        if (string.IsNullOrWhiteSpace(action)) return current;
        string normalized = action.Trim().ToLowerInvariant();
        if (normalized == "destroy") return null;
        if (normalized == "boost")
        {
            int newVelocity = System.Math.Min(MAX_VELOCITY_VALUE, current.Velocity + 1);
            int newSize = System.Math.Max(MIN_SIZE_VALUE, current.Size - 1);
            int newEccentricity = System.Math.Min(MAX_ECCENTRICITY_VALUE, current.Eccentricity + 1);
            int newVolatility = System.Math.Min(MAX_VOLATILITY_VALUE, current.Volatility + 1);
            return new Asteroid(
                newVelocity,
                newSize,
                true,
                current.IsIrregular,
                current.Composition,
                current.IsMultiplicity,
                newEccentricity,
                newVolatility,
                current.Integrity,
                current.Compact,
                current.Direction
            );
        }
        if (normalized == "weaken")
        {
            int newVelocity = System.Math.Max(MIN_VELOCITY_VALUE, current.Velocity - 1);
            int newSize = System.Math.Min(MAX_SIZE_VALUE, current.Size + 1);
            int newEccentricity = System.Math.Max(MIN_ECCENTRICITY_VALUE, current.Eccentricity - 1);
            int newVolatility = System.Math.Max(MIN_VOLATILITY_VALUE, current.Volatility - 1);
            return new Asteroid(
                newVelocity,
                newSize,
                false,
                current.IsIrregular,
                current.Composition,
                current.IsMultiplicity,
                newEccentricity,
                newVolatility,
                current.Integrity,
                current.Compact,
                current.Direction
            );
        }
        if (normalized == "scan") return current;
        return current;
    }

    private Asteroid GenerateAsteroid(int roundNumberInput, DirectionType direction)
    {
        var difficultyFactor = System.Math.Min(roundNumberInput, DIFFICULTY_ROUND_CAP) / DIFFICULTY_SCALE;

        int velocity = BiasUp(
            RandomInRange(MIN_VELOCITY_VALUE, MAX_VELOCITY_VALUE),
            MIN_VELOCITY_VALUE,
            MAX_VELOCITY_VALUE,
            difficultyFactor,
            VELOCITY_MAX_INCREMENT_AT_FULL_DIFFICULTY
        );

        int size = BiasDown(
            RandomInRange(MIN_SIZE_VALUE, MAX_SIZE_VALUE),
            MIN_SIZE_VALUE,
            MAX_SIZE_VALUE,
            difficultyFactor,
            SIZE_MAX_DECREMENT_AT_FULL_DIFFICULTY
        );

        bool isFastRotation = random.NextDouble() < (FAST_ROTATION_BASE_PROBABILITY + FAST_ROTATION_DIFFICULTY_SLOPE * difficultyFactor);
        bool isIrregular = random.NextDouble() < (IRREGULAR_BASE_PROBABILITY + IRREGULAR_DIFFICULTY_SLOPE * difficultyFactor);
        bool isMultiplicity = random.NextDouble() < (MULTIPLICITY_BASE_PROBABILITY + MULTIPLICITY_DIFFICULTY_SLOPE * difficultyFactor);

        int eccentricity = BiasUp(
            RandomInRange(MIN_ECCENTRICITY_VALUE, MAX_ECCENTRICITY_VALUE),
            MIN_ECCENTRICITY_VALUE,
            MAX_ECCENTRICITY_VALUE,
            difficultyFactor,
            ECCENTRICITY_MAX_INCREMENT_AT_FULL_DIFFICULTY
        );

        int volatility = BiasUp(
            RandomInRange(MIN_VOLATILITY_VALUE, MAX_VOLATILITY_VALUE),
            MIN_VOLATILITY_VALUE,
            MAX_VOLATILITY_VALUE,
            difficultyFactor,
            VOLATILITY_MAX_INCREMENT_AT_FULL_DIFFICULTY
        );

        int compact = BiasUp(
            RandomInRange(MIN_COMPACT_VALUE, MAX_COMPACT_VALUE),
            MIN_COMPACT_VALUE,
            MAX_COMPACT_VALUE,
            difficultyFactor,
            COMPACT_MAX_INCREMENT_AT_FULL_DIFFICULTY
        );

        CompositionType composition = WeightedComposition(difficultyFactor);
        IntegrityType integrity = WeightedIntegrity();

        return new Asteroid(
            velocity,
            size,
            isFastRotation,
            isIrregular,
            composition,
            isMultiplicity,
            eccentricity,
            volatility,
            integrity,
            compact,
            direction
        );
    }

    private AsteroidDto?[] MapStoreToDtos()
    {
        var result = new AsteroidDto?[QUADRANT_COUNT];
        for (int i = 0; i < QUADRANT_COUNT; i++)
        {
            var model = activeAsteroids[i];
            result[i] = model is null ? null : MapToDto(model);
        }
        return result;
    }

    private AsteroidDto MapToDto(Asteroid model)
    {
        if (model.Brightness <= BRIGHTNESS_LEVEL_NONE_MAX)
        {
            return new AsteroidDto(
                model.Velocity,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
        }
        if (model.Brightness <= BRIGHTNESS_LEVEL_BASIC_MAX)
        {
            return new AsteroidDto(
                model.Velocity,
                model.Size,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );
        }
        if (model.Brightness <= BRIGHTNESS_LEVEL_INTERMEDIATE_MAX)
        {
            return new AsteroidDto(
                model.Velocity,
                model.Size,
                model.IsFastRotation,
                model.IsIrregular,
                model.Composition,
                null,
                null,
                null,
                null,
                model.Compact
            );
        }
        return new AsteroidDto(
            model.Velocity,
            model.Size,
            model.IsFastRotation,
            model.IsIrregular,
            model.Composition,
            model.IsMultiplicity,
            model.Eccentricity,
            model.Volatility,
            model.Integrity,
            model.Compact
        );
    }

    private int RandomInRange(int minimumValue, int maximumValue)
    {
        return random.Next(minimumValue, maximumValue + 1);
    }

    private int BiasUp(int baseValue, int minimumValue, int maximumValue, double difficultyFactor, int maxIncrementAtFullDifficulty)
    {
        int randomIncrement = random.Next(0, 1 + (int)System.Math.Round(difficultyFactor * maxIncrementAtFullDifficulty));
        int result = baseValue + randomIncrement;
        if (result > maximumValue) result = maximumValue;
        if (result < minimumValue) result = minimumValue;
        return result;
    }

    private int BiasDown(int baseValue, int minimumValue, int maximumValue, double difficultyFactor, int maxDecrementAtFullDifficulty)
    {
        int randomDecrement = random.Next(0, 1 + (int)System.Math.Round(difficultyFactor * maxDecrementAtFullDifficulty));
        int result = baseValue - randomDecrement;
        if (result > maximumValue) result = maximumValue;
        if (result < minimumValue) result = minimumValue;
        return result;
    }

    private CompositionType WeightedComposition(double difficultyFactor)
    {
        double randomRoll = random.NextDouble();
        double metalProbability = METAL_BASE_PROBABILITY + METAL_DIFFICULTY_SLOPE * difficultyFactor;
        double silicateProbability = SILICATE_BASE_PROBABILITY + SILICATE_DIFFICULTY_SLOPE * difficultyFactor;
        if (randomRoll < metalProbability) return CompositionType.MetalBased;
        if (randomRoll < metalProbability + silicateProbability) return CompositionType.SilicateBased;
        return CompositionType.CarbonBased;
    }

    private IntegrityType WeightedIntegrity()
    {
        int randomIndex = random.Next(0, 4);
        return randomIndex switch
        {
            0 => IntegrityType.RubblePileSmall,
            1 => IntegrityType.RubblePileMedium,
            2 => IntegrityType.RubblePileLarge,
            _ => IntegrityType.Compact
        };
    }
}