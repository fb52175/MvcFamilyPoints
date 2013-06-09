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
        public int ChildID { get; set; }
        public int ParentID { get; set; }
        public string PointType { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
    }
}