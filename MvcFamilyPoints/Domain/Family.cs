using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcFamilyPoints.Domain
{
    public class Family
    {
        public int FamilyID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
        public virtual ICollection<Child> Children { get; set; }

    }

    

}