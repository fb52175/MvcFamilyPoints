using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;
using System;


namespace FamilyPoints.Business
{
    public class TransactionMgr : Manager
    {
        public FamilyPointsContext context;

        public TransactionMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public TransactionMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            
            transactionSvc.Insert(transaction);
            transactionSvc.Save();
        }

        public void Update(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            transactionSvc.Update(transaction);
            transactionSvc.Save();
        }

        public void Delete(Transaction transaction)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            transactionSvc.Delete(transaction);
            transactionSvc.Save();
        }

        public Transaction Find(int id)
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            return transactionSvc.GetById(id);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            ITransactionSvc transactionSvc = (ITransactionSvc)GetService(typeof(ITransactionSvc).Name, context);
            return transactionSvc.GetAll();
        }

    }
}
