namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface ILieutenantGeneral
    {
        IReadOnlyCollection<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
