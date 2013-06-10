using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class ParentMgr
    {
        public void Create(Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc");

            parentSvc.Insert(parent);
            parentSvc.Save();
        }

        public void Update(Parent parent, string name, string password)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc");
            parent.Name = name;
            parent.Password = password;
            parentSvc.Update(parent);
            parentSvc.Save();
        }

        public void Delete(Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc");

            parentSvc.Delete(parent);
            parentSvc.Save();
        }

        public Parent Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc");
            return parentSvc.GetById(id);
        }

        public IEnumerable<Parent> GetParents()
        {
            Factory factory = Factory.GetInstance();
            IParentSvc parentSvc = (IParentSvc)factory.GetService("IParentSvc");
            return parentSvc.GetParents();
        }
    }
}
