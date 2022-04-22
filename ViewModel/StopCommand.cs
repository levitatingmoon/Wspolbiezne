using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class StopCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public AppWindow appWindow;

        public StopCommand(AppWindow appWindow)
        {
            this.appWindow = appWindow;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            appWindow.ButtonStopClick();
        }
    }
}