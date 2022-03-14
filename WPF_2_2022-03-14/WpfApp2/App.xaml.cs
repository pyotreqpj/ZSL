using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IMyWindow CurrentWindow;

        public static void NavigateTo<T>() where T : new()
        {
            var page = new T();
            CurrentWindow.NavigateTo(page);
        }
    }
}
