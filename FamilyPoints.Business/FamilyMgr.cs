using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        public void Delete(Family family)
        {
            IFamilySvc familySvc = (IFamilySvc)GetService(typeof(IFamilySvc).Name, context);
            IChildSvc childSvc = (IChildSvc)GetService(typeof(IChildSvc).Name, context);
            IParentSvc parentSvc = (IParentSvc)GetService(typeof(IParentSvc).Name, context);
            ChildMgr childMgr = new ChildMgr(context);
            ParentMgr parentMgr = new ParentMgr(context);

            if (family.Children != null)
            {
                foreach (Child child in family.Children.ToList())
                {
                    childMgr.Delete(child);
                }
            }

            if (family.Parents != null)
            {
                foreach (Parent parent in family.Parents.ToList())
                {
                    parentMgr.Delete(parent);
                }
            }
            familySvc.Delete(family);
            familySvc.Save();
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
