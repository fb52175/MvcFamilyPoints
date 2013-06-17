using System;
using System.Collections.ObjectModel;
using FamilyPoints.Domain;
using FamilyPoints.Service;
using System.Collections.Generic;

namespace FamilyPoints.Business
{
    public class FamilyMgr :Manager
    {
        public FamilyPointsContext context;
        public IFamilySvc familySvc;

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
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            //Family dup = familySvc.Single(c => c.FamilyName.Equals(family.FamilyName));
            familySvc.Insert(family);
            familySvc.Save();
        }

        public void Update(Family family)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            familySvc.Update(family);
            familySvc.Save();
        }

        public void AddChild(Family family, Child child)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            //if (family.Children == null)
            //    family.Children = new Collection<Child>();
            //family.Children.Add(child);
            familySvc.Update(family);
            familySvc.Save();
        }


        public void AddParent(Family family, Parent parent)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            //if (family.Parents == null)
            //    family.Parents = new Collection<Parent>();
            //family.Parents.Add(parent);
            familySvc.Update(family);
            familySvc.Save();
        }

        public bool Delete(Family family)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            if (family.Parents != null || family.Children !=null)
                return false;
            try
            {
                familySvc.Delete(family);
                familySvc.Save();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        
        }

        public Family Find(int id)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            Family family = familySvc.GetById(id);
            return family;
        }

        public IEnumerable<Family> GetFamilies()
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            return familySvc.GetAll();
        }

    }
}
