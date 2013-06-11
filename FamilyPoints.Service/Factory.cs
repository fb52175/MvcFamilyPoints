using System;
using System.Collections.Specialized;
using System.Configuration;



namespace FamilyPoints.Service
{
    public class Factory
    {
        private Factory() { }
        private static Factory factory = new Factory();
        public static Factory GetInstance() { return factory; }

        public IService GetService(string serviceName,params object[] args)
        {
            Type type;
            Object obj = null;
            try
            {   
                type = Type.GetType(GetImplName(serviceName));   
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
