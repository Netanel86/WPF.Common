using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Common.Services
{
    /// <summary>
    /// Defines a property for accessing a navigation service
    /// </summary>
    /// <remarks>
    /// Interface should be implemented in viewmodel of view's which are navigable.  
    /// </remarks>
    public interface INavigable
    {
        INavigationService Navigator { get; set; }
    }
}
