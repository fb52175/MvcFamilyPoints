using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class TransactionMgr
    {
        public void Create(Transaction transaction)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc");

            transactionSvc.Insert(transaction);
            transactionSvc.Save();
        }

        public void Update(Transaction transaction, string description, int points)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc");
            transaction.Description = description;
            transaction.Points = points;
            transactionSvc.Update(transaction);
            transactionSvc.Save();
        }

        public void Delete(Transaction transaction)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc");

            transactionSvc.Delete(transaction);
            transactionSvc.Save();
        }

        public Transaction Find(int id)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc");
            return transactionSvc.GetById(id);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc");
            return transactionSvc.GetTransactions();
        }
    }
}
