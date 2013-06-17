using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPoints.Domain
{
    public class Family
    {
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
        public virtual ICollection<Child> Children { get; set; }

    }

    

}