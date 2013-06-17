using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FamilyPoints.Service;

namespace FamilyPoints.Business
{
    public abstract class Manager
    {
        private Factory factory = Factory.GetInstance();
        protected IService GetService(String name,params object[] args)
        {
            return factory.GetService(name, args);
        }
    }
}
