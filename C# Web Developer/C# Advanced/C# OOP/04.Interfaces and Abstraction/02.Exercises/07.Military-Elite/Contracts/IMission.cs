using _07.Military_Elite.Enumerations;

namespace _07.Military_Elite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}