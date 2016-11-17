using WPF.Common.Aggregators;
using System;
using WPF.Common.Services;

namespace WPF.Common.ViewModel
{
    /// <summary>
    /// A base view model class, which holds application Messanger
    /// to interact with view components.
    /// </summary>
    public class ViewModelBase : BindableObject
    {
        private static readonly IEventAggregator sr_Messanger = new EventAggregator();
        private static readonly IServiceManager sr_Services = new ServiceManager();
        
        /// <summary>
        /// Gets a static instance of a Messanger service
        /// </summary>
        protected IEventAggregator Messanger
        {
            get { return sr_Messanger; }
        }

        /// <summary>
        /// Gets a static instance of a Service manager
        /// </summary>
        protected IServiceManager Services
        {
            get { return sr_Services; }
        }
    }

}
