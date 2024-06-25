namespace Xelit3.Playground.EventSourcing;

public class BankAccount
{
    public Guid AccountId { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public decimal Balance { get; private set; } = 0;


    public void Apply(Event @event)
    {
        switch (@event)
        {
            case BankAccountCreated bankAccountCreated:
                Apply(bankAccountCreated);
                break;

            case BankAccountBalanceChanged bankAccountBalanceChanged:
                Apply(bankAccountBalanceChanged);
                break;
        }
    }

    private void Apply(BankAccountCreated bankAccountCreated)
    {
        AccountId = bankAccountCreated.StreamId;
        Number = bankAccountCreated.Number;
        Balance = 0;
    }

    private void Apply(BankAccountBalanceChanged bankAccountBalanceChanged)
    {
        Balance += bankAccountBalanceChanged.Quantity;
    }
}
