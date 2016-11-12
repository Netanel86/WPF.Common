using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.Messaging;

namespace WPF.Common.Services
{
    /// <summary>
    /// Defines methods for navigating threw views
    /// </summary>
    /// <remarks>
    /// Interface should be implemented by a behavior that handles the presentation of new views.
    /// </remarks>
    public interface INavigationService
    {
        void NavigateTo(Type i_ControlType, Action<object> i_Completed);

        void NavigateTo(Type i_ControlType, Action<object> i_Completed, object i_InitialValue);

        void NavigateTo(IMessageModel i_MessageModel, Action<object> i_Completed);

        void NavigateBackwards(object i_Result);

        event EventHandler ViewChanged;
    }
}
