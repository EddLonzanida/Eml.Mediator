namespace Eml.Mediator.Tests.Common.Classes;

public interface IUser<out T> : IDiDiscoverableTransient
{
    T? Id { get; }
}
