namespace FailSafeProtocol.Domain;

public interface AsteroidService
{
    AsteroidDto?[] GetAsteroid(int ante);
    AsteroidDto?[] CalculateStates(string?[] input);
}
