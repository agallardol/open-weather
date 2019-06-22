﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace OpenWeatherApp.Commands
{
    public class RelayCommand : ICommand
    {
        readonly SynchronizationContext synchronizationContext = Dispatcher.CurrentDispatcher.Invoke<SynchronizationContext>(() => SynchronizationContext.Current);
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        protected virtual void OnCanExecuteChange()
        {
            if (synchronizationContext != null && synchronizationContext != SynchronizationContext.Current)
                synchronizationContext.Post((o) => CanExecuteChanged?.Invoke(this, new EventArgs()), null);
            
        }
    }
}
