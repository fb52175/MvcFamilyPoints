using System.Collections.Generic;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public interface ITransactionSvc
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