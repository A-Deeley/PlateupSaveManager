using PlateupSaveManager.Interfaces;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace PlateupSaveManager.Extensions
{
    internal static class SaveManagerExtensions
    {
        internal static TPage SetDataContext<TPage, TDataContext>(this TPage page, TDataContext context)
            where TPage : Page
            where TDataContext : IChangeView
        {
            page.DataContext = context;
            return page;
        }

        internal static ObservableCollection<TClass> ConvertToObservable<TClass>(this IEnumerable<TClass> list)
            where TClass : class
        {
            return new ObservableCollection<TClass>(list);
        }

        internal static bool IsOfType<TType>(this Page page) => page.GetType() == typeof(TType);

        internal static IEnumerable<TClass> ToEnumerable<TClass>(this object data) => (IEnumerable<TClass>)data;
    }
}
