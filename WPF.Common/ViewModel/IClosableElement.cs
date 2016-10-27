using System;

namespace WPF.Common.ViewModel
{
    public interface IClosableElement
    {
        event EventHandler CloseRequest;
        void Close();
    }
}
