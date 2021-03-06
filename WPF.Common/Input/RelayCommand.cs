using System;
using System.Windows.Input;

namespace WPF.Common.Input
{
    public class RelayCommand : CommandBase
    {
        private Predicate<object> m_CanExecute;
        private Action<object> m_Execute;

        private bool m_CanExecuteCurrentState;

        public RelayCommand(Action<object> i_Execute, Predicate<object> i_CanExecute)
        {
            if (i_Execute == null)
            {
                throw new ArgumentNullException("i_Execute");
            }

            if (i_CanExecute == null)
            {
                throw new ArgumentNullException("i_CanExecute");
            }

            m_CanExecute = i_CanExecute;
            m_Execute = i_Execute;
        }

        public RelayCommand(Action<object> i_Execute)
            : this(i_Execute, x => true)
        { }

        public override bool CanExecute(object parameter)
        {
            if (this.m_CanExecute != null)
            {
                bool canExecute = this.m_CanExecute(parameter);
                if (m_CanExecuteCurrentState != canExecute)
                {
                    m_CanExecuteCurrentState = canExecute;
                    OnCanExecuteChanged();
                }
            }

            return m_CanExecuteCurrentState;
        }

        public override void Execute(object parameter)
        {
            this.m_Execute(parameter);
        }
    }
}
