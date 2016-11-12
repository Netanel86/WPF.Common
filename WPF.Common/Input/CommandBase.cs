using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPF.Common.Input
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;
        protected void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public virtual void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
