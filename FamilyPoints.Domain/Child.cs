using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPoints.Domain
{
    public class Child
    {
        public int ChildId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int CurrentPoints { get; set; }
        public int FamilyId { get; set; }

        public virtual Family Family { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}