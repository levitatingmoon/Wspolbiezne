using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class StartCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AppWindow appWindow;

        public StartCommand(AppWindow appWindow)
        {
            this.appWindow = appWindow;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            appWindow.ButtonClick();
        }
    }
}
