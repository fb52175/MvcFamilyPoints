using System.Collections.ObjectModel;
using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class FamilyMgr
    {
        public FamilyPointsContext context;

        public FamilyMgr()
        {
            this.context=new FamilyPointsContext();
        }

        public FamilyMgr(FamilyPointsContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(Family family)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc", context);

            familySvc.Insert(family);
            familySvc.Save();
        }

        public void Update(Family family)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",context);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void AddChild(Family family, Child child)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",context);
            if (family.Children == null)
                family.Children = new Collection<Child>();
            family.Children.Add(child);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void AddParent(Family family, Parent parent)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",context);
            if(family.Parents == null)
                family.Parents=new Collection<Parent>();
            family.Parents.Add(parent);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void Delete(Family family)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",context);
            familySvc.Delete(family);
            familySvc.Save();
        }

        public Family Find(int id)
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc", context);
            Family family = familySvc.GetById(id);
            return family;
        }

        public IEnumerable<Family> GetFamilies()
        {
            Factory factory = Factory.GetInstance();
            IFamilySvc familySvc = (IFamilySvc)factory.GetService("IFamilySvc",context);
            return familySvc.GetAll();
        }
    }
}
