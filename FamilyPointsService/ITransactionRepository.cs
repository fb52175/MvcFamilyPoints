using System.Collections.Generic;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetById(int id);
        void Insert(Transaction transaction);
        void Delete(int transactionId);
        void Delete(Transaction transaction);
        void Update(Transaction transaction);
        void Save();
        void Dispose();
    }
}