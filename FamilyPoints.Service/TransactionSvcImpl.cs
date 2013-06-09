using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    class TransactionSvcImpl : ITransactionSvc
    {
        private FamilyPointsContext context;

        public TransactionSvcImpl(FamilyPointsContext dbcontext)
        {
            if (context == null)
                dbcontext = new FamilyPointsContext();
            this.context = dbcontext;
            if (context == null) throw new NullReferenceException("dbContext");
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
