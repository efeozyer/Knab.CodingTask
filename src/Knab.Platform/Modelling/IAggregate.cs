namespace Knab.Platform.Modelling;

public interface IAggregate
{
    IReadOnlyCollection<IDomainEvent> Events { get; }
}