using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPointsDomain;

namespace FamilyPointsService
{
    public class RepositoryFactory
    {
        private FamilyPointsContext context = new FamilyPointsContext();
        private IRewardRepository rewardRepository;
        private IBehaviorRepository behaviorRepository;
        private IFamilyRepository familyRepository;
        private IParentRepository parentRepository;
        private IChildRepository childRepository;
        private ITransactionRepository transactionRepository;

        public IRewardRepository RewardRepository
        {
            get { return rewardRepository ?? (rewardRepository = new RewardRepositoryImpl(context)); }
        }

        public IBehaviorRepository BehaviorRepository
        {
            get { return behaviorRepository ?? (behaviorRepository = new BehaviorRepositoryImpl(context)); }
        }

        public IFamilyRepository FamilyRepository
        {
            get { return familyRepository ?? (familyRepository = new FamilyRepository(context)); }
        }

        public IParentRepository ParentRepository
        {
            get { return parentRepository ?? (parentRepository = new ParentRepositoryImpl(context)); }
        }

        public IChildRepository ChildRepository
        {
            get { return childRepository ?? (childRepository = new ChildRepositoryImpl(context)); }
        }

        public ITransactionRepository TransactionRepository
        {
            get { return transactionRepository ?? (transactionRepository = new TransactionRepositoryImpl(context)); }
        }
       

        
    }
}
