using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.ViewModel;
using System.Windows.Input;
using WPF.Common.Services;

namespace WPF.Common.Messaging
{
    /// <summary>
    /// Defines properties to interact with a message class
    /// </summary>
    /// <remarks>
    /// Interface should be implemented in message classes presented with the <see cref="Navigator"/> class
    /// </remarks>
    public interface IMessageModel
    {
        string Title { get; }
        string Text { get; }
        string Content { get; }
        eMessageIcon Icon { get; }
    }
}
