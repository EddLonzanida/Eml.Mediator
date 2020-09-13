#if NETFULL
using System.ComponentModel.Composition;
#endif
#if NETCORE
using System.Composition;
#endif

namespace Eml.Mediator.Tests.Common.Classes
{
    [Export]
    public class User<T> : IUser<T>
    {
        public T Id { get; set; }
    }
}
