using System;
using System.Windows.Input;
using WPF.Common.Input;

namespace WPF.Common.ViewModel
{
    /// <summary>
    /// Abstract represntaion of a dialog view model
    /// </summary>
    public abstract class DialogModel : ViewModelBase, IDialogModel
    {
        /// <summary>
        /// Gets\Sets the default value for the dialog
        /// </summary>
        public object DefaultValue { get; set; }

        private const bool v_DialogCanceled = true;

        /// <summary>
        /// Ok button command
        /// </summary>
        /// <remarks>
        /// closes the dialog with a call to <see cref="CloseDialog"/>(true) method.
        /// </remarks>
        public ICommand OkCommand
        { get; private set; }

        /// <summary>
        /// Cancel button command
        /// </summary>
        /// <remarks>
        /// closes the dialog with a call to <see cref="CloseDialog"/>(false) method.
        /// </remarks>
        public ICommand CancelCommand
        { get; private set; }

        /// <summary>
        /// command for injecting logics on view's unload
        /// </summary>
        /// <remarks>
        /// Invokes <see cref="Unload"/> method.
        /// <see cref="Unload"/> must be overrided when binding to this command.
        /// </remarks>
        public ICommand OnUnloadCommand
        { get; private set; }

        /// <summary>
        /// command for injecting logics on view's load
        /// </summary>
        /// <remarks>
        /// Invokes <see cref="Load"/> method.
        /// <see cref="Load"/> must be overrided when binding to this command.
        /// </remarks>
        public ICommand OnLoadCommand
        { get; private set; }

        public DialogModel()
        {
            OkCommand = new RelayCommand((x) => CloseDialog(!v_DialogCanceled), (x) => CheckResultLegitimacy());
            CancelCommand = new RelayCommand((x) => CloseDialog(v_DialogCanceled));
            
            OnUnloadCommand = new RelayCommand((x) => Unload());
            OnLoadCommand = new RelayCommand((x) => Load());
        }

        /// <summary>
        /// checks the legitimacy the dialog result
        /// </summary>
        /// <returns>true if legitimate false otherwise</returns>
        /// <remarks>
        /// implement with your own logics
        /// </remarks>
        protected abstract bool CheckResultLegitimacy();

        /// <summary>
        /// Closes the dialog
        /// </summary>
        /// <param name="i_DialogCanceled">if the dialog was canceled</param>
        /// <remarks>
        /// implement with your own logics
        /// </remarks>
        protected abstract void CloseDialog(bool i_DialogCanceled);

        /// <summary>
        /// called when view represented by the model unloads
        /// </summary>
        /// <remarks>
        /// override with your own unload logics.
        /// a binding to <see cref="OnUnloadCommand"/>, and registration of command to view's unload event is necessary.
        /// </remarks>
        protected virtual void Unload()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// called when view represented by the model loads
        /// </summary>
        /// <remarks>
        /// override with your own load logics.
        /// a binding to <see cref="OnLoadCommand"/>, and registration of command to view's load event is necessary.
        /// </remarks>
        protected virtual void Load()
        {
            throw new NotImplementedException();
        }



    }
}
