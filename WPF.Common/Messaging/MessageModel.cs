using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.ViewModel;
using WPF.Common.Services;
using System.Windows.Input;
using WPF.Common.Input;

namespace WPF.Common.Messaging
{
    public class MessageModel : ViewModelBase, IMessageModel, INavigable
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Content { get; set; }
        public eMessageIcon Icon { get; set; }

        public MessageModel()
        {
            DefaultButtonCommand = new RelayCommand(x => this.Navigator.NavigateBackwards(null));
        }

        public ICommand DefaultButtonCommand { set; get; }

        private INavigationService m_Navigator;
        public INavigationService Navigator
        {
            get
            {
                return m_Navigator;
            }
            set
            {
                m_Navigator = value;
            }
        }
    }
}
