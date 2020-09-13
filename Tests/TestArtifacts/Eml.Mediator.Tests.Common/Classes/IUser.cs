namespace Eml.Mediator.Tests.Common.Classes
{
    public interface IUser<out T>
    {
        T Id { get; }
    }
}