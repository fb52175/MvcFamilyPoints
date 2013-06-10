using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class ChildMgr
    {
        public void Create(Child child)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc");

            childSvc.Insert(child);
            childSvc.Save();
        }

        public void Update(Child child, string name, string password)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc");
            child.Name = name;
            child.Password = password;
            childSvc.Update(child);
            childSvc.Save();
        }

        public void Delete(Child child)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc");

            childSvc.Delete(child);
            childSvc.Save();
        }

        public Child Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc");
            return childSvc.GetById(id);
        }

        public IEnumerable<Child> GetChildren()
        {
            Factory factory = Factory.GetInstance();
            IChildSvc childSvc = (IChildSvc)factory.GetService("IChildSvc");
            return childSvc.GetChildren();
        }
    }
}
