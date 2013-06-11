using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public class ChildSvcImpl: Repository<Child>, IChildSvc
    {
        public ChildSvcImpl(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

