using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public class BehaviorSvcImpl: Repository<Behavior>, IBehaviorSvc
    {
        public BehaviorSvcImpl(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

