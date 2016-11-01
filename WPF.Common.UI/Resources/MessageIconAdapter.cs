using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPF.Common.UI.Converters;
using WPF.Common.Messaging;

namespace WPF.Common.UI.Resources
{
    public class MessageIconAdapter : IResourceAdapter
    {
        private const string m_ApplicationPath = @"pack://application:,,,/WPF.Common.UI;component/Icons/";

        public object GetResource(object i_ResourceName)
        {
            string resourceString = String.Empty;

            switch ((eMessageIcon)i_ResourceName)
            {
                case eMessageIcon.Close:
                    resourceString = MessageIcons.Close;
                    break;
                case eMessageIcon.Exclamation:
                    resourceString = MessageIcons.Exclamation;
                    break;
                case eMessageIcon.Info:
                    resourceString = MessageIcons.Info;
                    break;
                case eMessageIcon.Warning:
                    resourceString = MessageIcons.Warning;
                    break;

                case eMessageIcon.OK:
                    resourceString = MessageIcons.OK;
                    break;
            }

            return m_ApplicationPath + resourceString;
        }
    }
}
