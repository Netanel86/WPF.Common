using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Common.Services
{
    public interface IServiceManager
    {
        object GetService(Type i_ServiceKey);
        void AddService(Type i_ServiceKey, object i_Service);
        void RemoveService(Type i_ServiceKey);
    }

    public class ServiceManager : IServiceManager
    {
        private readonly Dictionary<Type, object> m_Services = new Dictionary<Type, object>();
        
        public object GetService(Type i_ServiceKey)
        {
            object service = null;

            if (!m_Services.TryGetValue(i_ServiceKey, out service))
            {
                throw new ServiceNotFoundException(i_ServiceKey.Name);
            }

            return service;
        }

        public void AddService(Type i_ServiceKey, object i_Service)
        {
            m_Services.Add(i_ServiceKey, i_Service);
        }

        public void RemoveService(Type i_ServiceKey)
        {
            if (!m_Services.Remove(i_ServiceKey))
            {
                throw new ServiceNotFoundException(i_ServiceKey.Name);
            }
        }

        protected class ServiceNotFoundException : ArgumentException
        {
            public ServiceNotFoundException(string i_ParamName)
                : base("The specified service type does not exist in the collection", i_ParamName)
            {

            }
        }
    }
}
