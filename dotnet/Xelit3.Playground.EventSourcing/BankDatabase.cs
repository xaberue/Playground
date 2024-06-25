
using Xelit3.Playground.EventSourcing;

public class BankDatabase
{

    private readonly Dictionary<Guid, SortedList<DateTime, Event>> _bankAccounts = new();

    public void Append(Event @event)
    {
        var stream = _bankAccounts.GetValueOrDefault(@event.StreamId, null);

        if (stream is null)
        {
            _bankAccounts[@event.StreamId] = new SortedList<DateTime, Event>();
        }

        _bankAccounts[@event.StreamId].Add(@event.CreationDate, @event);
    }


    public BankAccount? GetAccount(Guid accountId)
    {
        if (!_bankAccounts.ContainsKey(accountId))
        {
            return null;
        }

        var account = new BankAccount();
        var events = _bankAccounts[accountId];

        foreach (var @event in events)
        {
            account.Apply(@event.Value);
        }

        return account;
    }

}
