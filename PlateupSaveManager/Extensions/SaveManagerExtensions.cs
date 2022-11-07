using PlateupSaveManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlateupSaveManager.Extensions
{
    internal static class SaveManagerExtensions
    {
        internal static TPage SetDataContext<TPage, TDataContext>(this TPage page, TDataContext context)
            where TPage : Page
            where TDataContext : IDataContext
        {
            page.DataContext = context;
            return page;
        }

        internal static ObservableCollection<TClass> ConvertToObservable<TClass>(this IEnumerable<TClass> list)
            where TClass : class
        {
            return new ObservableCollection<TClass>(list);
        }
    }
}
