using FamilyPoints.Domain;

namespace FamilyPoints.Service
{
    public class FamilySvcImpl: Repository<Family>, IFamilySvc
    {
        public FamilySvcImpl(FamilyPointsContext context)
            : base(context)
        { }

    } 

}

