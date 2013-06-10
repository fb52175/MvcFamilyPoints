using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Domain;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public class FamilyMgr
    {
        public void Create(Family family)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");

            familySvc.Insert(family);
            familySvc.Save();
        }

        public void Update(Family family, string name)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");
            family.Name = name;
            familySvc.Update(family);
            familySvc.Save();
        }

        public void AddChild(Family family, Child child)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");
            family.Children.Add(child);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void AddParent(Family family, Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");
            family.Parents.Add(parent);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void Delete(Family family)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");

            familySvc.Delete(family);
            familySvc.Save();
        }

        public Family Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");
            Family family = familySvc.GetById(id);
            //familySvc.Dispose();
            return family;
        }

        public IEnumerable<Family> GetFamilies()
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc");
            return familySvc.GetFamilies();
        }
    }
}
