namespace Eml.Mediator.Tests.Common.Classes
{
    public class User<T> : IUser<T>
    {
        public T? Id { get; set; }
    }
}
