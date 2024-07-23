namespace Xelit3.Playground.EventSourcing;

public abstract class Event
{
    public abstract Guid StreamId { get; set; }
    public DateTime CreationDate { get; set; }
    public Guid CreatedBy { get; set; }
}


public class BankAccountCreated : Event
{
    public override Guid StreamId { get ; set; }
    public required Guid OwnerId { get; set; }
    public required string Number { get; set; }
}

public class BankAccountBalanceChanged : Event
{
    public override Guid StreamId { get; set; }
    public required string Concept { get; set; }
    public required decimal Quantity { get; set; }
}