using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Common.UI.Converters
{
    /// <summary>
    /// provides a way to retrieve a resource by its represantation.
    /// </summary>
    /// <remarks>
    /// enables the use of enum represantion of icons and string in viewmodel's.
    /// used with <see cref="IValueConverter"/> as parameter.
    /// </remarks>
    /// <example>
    /// <code> 
    /// <Image Source="{Binding Icon, Converter={StaticResource GeneralBitmapConverter},ConverterParameter={StaticResource MyIconResourceAdapter}}" />
    /// </code>
    /// </example>
    public interface IResourceAdapter
    {
        /// <summary>
        /// Return a resource by its represantation format
        /// </summary>
        /// <param name="i_ResourceName">the represantation of the resource</param>
        /// <returns>the resource object itself</returns>
        object GetResource(object i_ResourceName);
    }
}
