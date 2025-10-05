namespace FailSafeProtocol.Domain;


public sealed class ContingencyResult
{
    public bool DeviatedFromEarth { get; }
    public bool SlightDeviation { get; }
    public int DestroyedTerrain { get; }
    public int SurvivingPopulation { get; }

    public ContingencyResult(bool deviatedFromEarth, bool slightDeviation, int destroyedTerrain, int survivingPopulation)
    {
        DeviatedFromEarth = deviatedFromEarth;
        SlightDeviation = slightDeviation;
        DestroyedTerrain = destroyedTerrain;
        SurvivingPopulation = survivingPopulation;
    }
}

public abstract class Contingency
{
    private readonly System.Random random = new System.Random();
    public abstract ContingencyResult Apply(Asteroid asteroid);

    protected bool desviationByInertia(int coningencyInertia, int asteroidInertia, int distance)
    {
        int residualInertia = asteroidInertia - coningencyInertia;
        if (residualInertia < 0) residualInertia = 0;
        if (residualInertia > 65) residualInertia = 65;
        double residualRatio = residualInertia / 65.0;
        double threshold = distance switch
        {
            1 => 0.70,
            2 => 0.60,
            3 => 0.50,
            4 => 0.40,
            _ => 0.20
        };
        return residualRatio < threshold;
    }

    protected int getDestroyedTerrain(Asteroid asteroid)
    {
        int sizeInMeters = asteroid.Size switch
        {
            1 => random.Next(20, 100),
            2 => random.Next(100, 1000),
            3 => random.Next(1000, 10000),
            4 => random.Next(10000, 100000),
            _ => random.Next(100000, 1000000)
        };
        int compactoToDensity = asteroid.Compact switch
        {
            1 => random.Next(1000, 2400),
            2 => random.Next(2400, 3800),
            3 => random.Next(3800, 5200),
            4 => random.Next(5200, 6600),
            _ => random.Next(6600, 8000)
        };
        int velocityInKmperSecond = asteroid.Velocity switch
        {
            1 => random.Next(10, 22),
            2 => random.Next(22, 34),
            3 => random.Next(34, 46),
            4 => random.Next(46, 58),
            _ => random.Next(58, 70)
        };

        double planetaryConstant = 0.52;

        int cubeMeters = sizeInMeters * sizeInMeters * sizeInMeters;

        double mass = planetaryConstant * cubeMeters * compactoToDensity;

        double impactEnergy = Math.Pow(mass, 0.26) * Math.Pow(velocityInKmperSecond, 0.44);

        double diametreInKm = (15 * impactEnergy) / 1000;

        return (int)diametreInKm;
    }
}

public sealed class WaitContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        int survivingPopulation = WorldData.GetCityPopulation(asteroid.City);
        int terrain = 100; // WorldData.GetCityTerrain
        if (asteroid.Distance == 5)
        {
            survivingPopulation = 0;
            terrain = terrain - this.getDestroyedTerrain(asteroid);
        }
        return new ContingencyResult(false, false, terrain, survivingPopulation);
    }
}

public sealed class EvacuateContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        int survivingPopulation = WorldData.GetCityPopulation(asteroid.City);
        int terrain = 100; // WorldData.GetCityTerrain
        if (asteroid.Distance == 5)
        {
            survivingPopulation = (int)(terrain * 0.75);
            terrain = terrain - this.getDestroyedTerrain(asteroid);
        }
        return new ContingencyResult(false, false, terrain, survivingPopulation);
    }
}

public sealed class ElectromagnetContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        int initialInertia = 5;
        if (asteroid.Composition == CompositionType.MetalBased)
        {
            initialInertia = initialInertia + 20;
        }
        bool desviatedFromEarth = this.desviationByInertia(initialInertia, asteroid.Inertia, asteroid.Distance);

        int survivingPopulation = WorldData.GetCityPopulation(asteroid.City);
        int terrain = 100; // WorldData.GetCityTerrain

        if ((asteroid.Distance == 5) && (!desviatedFromEarth))
        {
            survivingPopulation = 0;
            terrain = terrain - this.getDestroyedTerrain(asteroid);
        }
        return new ContingencyResult(desviatedFromEarth, false, terrain, survivingPopulation);
    }
}

public sealed class MiningContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        int initialInertia = 10;

        if (asteroid.Compact >= 4)
        {
            initialInertia = initialInertia - 2;
        }
        else if (asteroid.Integrity != IntegrityType.Compact)
        {
            initialInertia = initialInertia + ((4 - asteroid.Compact) * 4);
        }
        else
        {
            initialInertia = initialInertia + ((4 - asteroid.Compact) * 3);
        }
        
        bool desviatedFromEarth = this.desviationByInertia(initialInertia, asteroid.Inertia, asteroid.Distance);

        int survivingPopulation = WorldData.GetCityPopulation(asteroid.City);
        int terrain = 100; // WorldData.GetCityTerrain

        if ((asteroid.Distance == 5) && (!desviatedFromEarth))
        {
            survivingPopulation = 0;
            terrain = terrain - this.getDestroyedTerrain(asteroid);
        }
        return new ContingencyResult(desviatedFromEarth, false, terrain, survivingPopulation);
    }
}

public sealed class MirrorsContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        int initialInertia = 10;

        
        
        bool desviatedFromEarth = this.desviationByInertia(initialInertia, asteroid.Inertia, asteroid.Distance);

        int survivingPopulation = WorldData.GetCityPopulation(asteroid.City);
        int terrain = 100; // WorldData.GetCityTerrain

        if ((asteroid.Distance == 5) && (!desviatedFromEarth))
        {
            survivingPopulation = 0;
            terrain = terrain - this.getDestroyedTerrain(asteroid);
        }
        return new ContingencyResult(desviatedFromEarth, false, terrain, survivingPopulation);
    }
}

public sealed class PaintContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class LaserContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class TarpContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class RetroRocketsContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class GravityTractorContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class TowCablesContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class ProjectileContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class RemoteMiniBombsContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class NukeContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public sealed class ImpactOtherAsteroidContingency : Contingency
{
    public override ContingencyResult Apply(Asteroid asteroid)
    {
        return new ContingencyResult(false, false, 0, 0);
    }
}

public static class ContingencyFactory
{
    public static Contingency? Get(int index)
    {
        switch (index)
        {
            case 0: return new WaitContingency();
            case 1: return new EvacuateContingency();
            case 2: return new ElectromagnetContingency();
            case 3: return new MiningContingency();
            case 4: return new MirrorsContingency();
            case 5: return new PaintContingency();
            case 6: return new LaserContingency();
            case 7: return new TarpContingency();
            case 8: return new RetroRocketsContingency();
            case 9: return new GravityTractorContingency();
            case 10: return new TowCablesContingency();
            case 11: return new ProjectileContingency();
            case 12: return new RemoteMiniBombsContingency();
            case 13: return new NukeContingency();
            case 14: return new ImpactOtherAsteroidContingency();
            default: return null;
        }
    }
}