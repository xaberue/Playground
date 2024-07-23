
using Xelit3.Playground.EventSourcing;

public class BankDatabase
{

    private readonly Dictionary<Guid, SortedList<DateTime, Event>> _bankAccountsEvents = new();
    private readonly Dictionary<Guid, BankAccount> _bankAccounts = new();

    public void Append(Event @event)
    {
        var stream = _bankAccountsEvents.GetValueOrDefault(@event.StreamId, null);

        if (stream is null)
        {
            _bankAccountsEvents[@event.StreamId] = new SortedList<DateTime, Event>();
        }

        _bankAccountsEvents[@event.StreamId].Add(@event.CreationDate, @event);

        //This can be different, the simple approach is calculating the entire projection each time, but we can recover the last one and just apply the latest event on top of that
        _bankAccounts[@event.StreamId] = GetAccount(@event.StreamId);
    }


    public BankAccount? GetAccount(Guid accountId)
    {
        if (!_bankAccountsEvents.ContainsKey(accountId))
        {
            return null;
        }

        var account = new BankAccount();
        var events = _bankAccountsEvents[accountId];

        foreach (var @event in events)
        {
            account.Apply(@event.Value);
        }

        return account;
    }

    public BankAccount? GetAccountView(Guid accountId)
    {
        return _bankAccounts.GetValueOrDefault(accountId);
    }
}
