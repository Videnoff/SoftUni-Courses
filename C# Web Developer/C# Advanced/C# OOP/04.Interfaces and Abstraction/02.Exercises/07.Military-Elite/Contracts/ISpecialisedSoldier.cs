using _07.Military_Elite.Enumerations;

namespace _07.Military_Elite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}