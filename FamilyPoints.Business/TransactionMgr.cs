﻿using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;
using System;


namespace FamilyPoints.Business
{
    public class TransactionMgr
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
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc", context);

            transactionSvc.Insert(transaction);
            transactionSvc.Save();
        }

        public void Update(Transaction transaction, int parentId, int childId, string description, int points,string pointType)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc", context);
            transaction.Description = description;
            transaction.Points = points;
            transaction.ChildID = childId;
            transaction.ParentID = parentId;
            transaction.Date = DateTime.Now;
            transaction.PointType = pointType;
            transactionSvc.Update(transaction);
            transactionSvc.Save();
        }

        public void Delete(Transaction transaction)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc", context);

            transactionSvc.Delete(transaction);
            transactionSvc.Save();
        }

        public Transaction Find(int id)
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc", context);
            return transactionSvc.GetById(id);
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            Factory factory = Factory.GetInstance();
            ITransactionSvc transactionSvc = (ITransactionSvc)factory.GetService("ITransactionSvc", context);
            return transactionSvc.GetAll();
        }
    }
}
