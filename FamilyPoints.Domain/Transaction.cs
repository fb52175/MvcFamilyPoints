using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPoints.Domain
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public DateTime Date { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public string PointType { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        //public virtual Parent Parent { get; set; }
        //public virtual Child Child { get; set; }
    }
}