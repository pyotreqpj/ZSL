using System.Windows;
using WpfApp2.Views;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMyWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            App.CurrentWindow = this;
            ChildFrame.Content = new LoginPage();
        }

        public void NavigateTo<T>(T page) where T : new()
        {
            ChildFrame.Content = page;
        }
    }
}
