using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Common.Services
{
    /// <summary>
    /// Defines method for adding, removing and retrieving services
    /// </summary>
    public interface IServiceManager
    {
        object GetService(Type i_ServiceKey);
        void AddService(Type i_ServiceKey, object i_Service);
        void RemoveService(Type i_ServiceKey);
    }
}
