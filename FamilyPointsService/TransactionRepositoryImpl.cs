using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    class TransactionRepositoryImpl : ITransactionRepository
    {
        private FamilyPointsContext context;

        public TransactionRepositoryImpl(FamilyPointsContext context)
        {
            this.context = context;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return context.Transactions.ToList();
        }

        public Transaction GetById(int id)
        {
            return context.Transactions.Find(id);
        }

        public void Insert(Transaction transaction)
        {
            context.Transactions.Add(transaction);
        }

        public void Delete(int transactionId)
        {
            Transaction transaction = context.Transactions.Find(transactionId);
            context.Transactions.Remove(transaction);
        }

        public void Delete(Transaction transaction)
        {
            if (context.Entry(transaction).State == EntityState.Detached)
            {
                context.Transactions.Attach(transaction);
            }
            context.Transactions.Remove(transaction);
        }

        public void Update(Transaction transaction)
        {
            context.Entry(transaction).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
