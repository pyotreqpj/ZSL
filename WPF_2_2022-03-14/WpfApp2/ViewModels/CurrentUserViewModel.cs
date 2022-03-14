using WpfApp2.Data;

namespace WpfApp2.ViewModels
{
    public class CurrentUserViewModel
    {
        public string Login { get; set; }

        public CurrentUserViewModel()
        {
            Login = Users.CurrentUserLogin;
        }
    }
}
