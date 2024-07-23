using Xelit3.Playground.EventSourcing;

var bankDatabase = new BankDatabase();

var streamId = Guid.NewGuid();
var ownerId = Guid.NewGuid();
var employeeId  = Guid.NewGuid();

var accountCreated = new BankAccountCreated
{
    StreamId = streamId,
    CreatedBy = employeeId,
    CreationDate = DateTime.Now,
    Number = "XXXX XX 8885 9993 8883 3777",
    OwnerId = ownerId,
};

bankDatabase.Append(accountCreated);


var initialEarns = new BankAccountBalanceChanged
{
    StreamId = streamId,
    Concept = "Initial earnings transfer",
    CreationDate = DateTime.Now,
    CreatedBy = ownerId,
    Quantity = 1000
};

bankDatabase.Append(initialEarns);


var electricityBill = new BankAccountBalanceChanged
{
    StreamId = streamId,
    Concept = "Electricity bill",
    CreationDate = DateTime.Now,
    CreatedBy = ownerId,
    Quantity = -100
};

bankDatabase.Append(electricityBill);

var payroll = new BankAccountBalanceChanged
{
    StreamId = streamId,
    Concept = "Payroll",
    CreationDate = DateTime.Now,
    CreatedBy = ownerId,
    Quantity = 2000
};

bankDatabase.Append(payroll);


var account = bankDatabase.GetAccount(streamId);

Console.WriteLine($"Account: {account.Number} - {account.Balance}");