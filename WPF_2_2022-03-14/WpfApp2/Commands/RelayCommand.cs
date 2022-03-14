using System;
using System.Windows.Input;

namespace WpfApp2.Commands
{
    internal class RelayCommand : ICommand
    {
        private readonly Action action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action.Invoke();
        }
    }
}
