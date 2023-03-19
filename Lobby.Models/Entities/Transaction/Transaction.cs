using Lobby.Models.Enums;

namespace Lobby.Models.Entities.Transaction;

public class Transaction
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public decimal Amount { get; set; }

    public TransactionType TransactionType { get; set; }

    public DateTime TransactionDate { get; set; }

}