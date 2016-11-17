using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Common.Services
{
    /// <summary>
    /// Represents a collection of services.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        private readonly Dictionary<Type, object> m_Services = new Dictionary<Type, object>();
        
        /// <summary>
        /// Returns the reqeusted service from the collection
        /// </summary>
        /// <param name="i_ServiceKey">the type of the service</param>
        /// <returns>the service instance</returns>
        public object GetService(Type i_ServiceKey)
        {
            object service = null;

            if (!m_Services.TryGetValue(i_ServiceKey, out service))
            {
                throw new ServiceNotFoundException(i_ServiceKey.Name);
            }

            return service;
        }

        /// <summary>
        /// Add a service to the collection
        /// </summary>
        /// <param name="i_ServiceKey">the type of the service</param>
        /// <param name="i_Service">an instance of the service</param>
        public void AddService(Type i_ServiceKey, object i_Service)
        {
            m_Services.Add(i_ServiceKey, i_Service);
        }

        /// <summary>
        /// Remove a service from the collection
        /// </summary>
        /// <param name="i_ServiceKey">the type of the service</param>
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
