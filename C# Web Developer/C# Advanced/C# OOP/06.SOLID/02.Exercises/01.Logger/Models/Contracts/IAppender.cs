using _01.Logger.Models.Enumerations;

namespace _01.Logger.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        long MessagesAppended { get; }

        void Append(IError error);
    }
}