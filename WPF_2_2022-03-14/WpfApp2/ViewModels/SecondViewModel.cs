namespace WpfApp2.ViewModels
{
    public class SecondViewModel
    {
        public CurrentUserViewModel CurrentUserViewModel { get; set; }

        public SecondViewModel()
        {
            CurrentUserViewModel = new CurrentUserViewModel();
        }
    }
}
