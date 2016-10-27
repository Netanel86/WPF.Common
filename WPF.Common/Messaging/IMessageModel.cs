using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.ViewModel;
using System.Windows.Input;
using WPF.Common.Services;

namespace WPF.Common.Messaging
{
    public interface IMessageModel
    {
        string Title { get; }
        string Text { get; }
        string Content { get; }
        eMessageIcon Icon { get; }
    }
}
