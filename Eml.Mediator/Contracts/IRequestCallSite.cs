namespace Eml.Mediator.Contracts;

public interface IRequestCallSite
{
    /// <summary>
    /// Internally, this will be populated automatically, immediately right before the Execute call.
    /// </summary>
    string? CallSite { get; set; }
}
