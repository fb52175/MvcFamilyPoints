using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public class ParentSvcImpl: Repository<Parent>, IParentSvc
    {
        public ParentSvcImpl(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

