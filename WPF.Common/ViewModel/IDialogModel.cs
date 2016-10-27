using System.Windows.Input;

namespace WPF.Common.ViewModel
{
    public interface IDialogModel
    {
        object ReturnValue { get; }
        object DefaultValue { get; set; }
        ICommand OnUnloadCommand { get; }
        ICommand OnLoadCommand { get; }
        
        ICommand OkCommand { get; }
        ICommand CancelCommand { get; }
    }
}
