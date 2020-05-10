using System.Collections.Generic;

namespace _07.Military_Elite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }

        void AddPrivate(ISoldier @private);
    }
}