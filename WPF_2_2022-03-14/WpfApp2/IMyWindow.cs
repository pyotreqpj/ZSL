namespace WpfApp2
{
    public interface IMyWindow
    {
        void NavigateTo<T>(T page) where T : new();
    }
}
