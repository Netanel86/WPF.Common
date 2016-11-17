using System;
using System.Windows.Input;
using WPF.Common.Input;

namespace WPF.Common.ViewModel
{
    public abstract class DialogModel : ViewModelBase, IDialogModel
    {
        public object DefaultValue { get; set; }

        private const bool v_DialogCanceled = true;

        public ICommand OkCommand
        { get; private set; }

        public ICommand CancelCommand
        { get; private set; }

        public ICommand OnUnloadCommand
        { get; private set; }

        public ICommand OnLoadCommand
        { get; private set; }

        public DialogModel()
        {
            OkCommand = new RelayCommand((x) => CloseDialog(!v_DialogCanceled), (x) => CheckResultLegitimacy());
            CancelCommand = new RelayCommand((x) => CloseDialog(v_DialogCanceled));
            
            OnUnloadCommand = new RelayCommand((x) => Unload());
            OnLoadCommand = new RelayCommand((x) => Load());
        }

        public void Close()
        {
            this.CloseDialog(true);
        }

        protected abstract bool CheckResultLegitimacy();

        protected abstract void CloseDialog(bool i_DialogCanceled);

        protected virtual void Unload()
        {
            throw new NotImplementedException();
        }

        protected virtual void Load()
        {
            throw new NotImplementedException();
        }



    }
}
