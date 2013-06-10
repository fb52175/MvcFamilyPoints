using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FamilyPoints.Domain;
using System.Configuration;
using System.Collections.Specialized;



namespace FamilyPoints.Service
{
    public class Factory
    {
        private Factory() { }
        private static Factory factory = new Factory();
        public static Factory GetInstance() { return factory; }

        public IService GetService(string serviceName)
        {
            Type type;
            Object obj = null;
            try
            {   
                object args = null;
                type = Type.GetType(GetImplName(serviceName));
               //object repository = Activator.CreateInstance(Type.GetType(repositoryName), args);
                
                obj = Activator.CreateInstance(type,args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }
            return (IService)obj;  
        }

        private string GetImplName(string servicename)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            return settings.Get(servicename);
        }
    }
}
