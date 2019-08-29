using System;
using System.Windows.Input;

namespace CMTranslator.Helpers
{
    /// <summary>
    /// Implements and extends ICommand interface
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Constructors

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        #endregion

        #region Properties

        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        #endregion

        #region Methods

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Returns true if the action is able to execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Executes the bound action
        /// </summary>
        /// <param name="parameter">The action to be executed</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        #endregion
    }
}
