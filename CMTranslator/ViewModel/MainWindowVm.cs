using CMTranslator.Helpers;
using CMTranslator.View.Fragments;
using System.Collections.Generic;

namespace CMTranslator.ViewModel
{
    /// <summary>
    /// Viewmodel for application main window
    /// </summary>
    class MainWindowVm
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowVm()
        {
            ExitApplicationButton = new RelayCommand(exit);
        }

        #endregion

        #region Members

        public List<CloseableTab> ActiveTabs { get; set; }
        public int ActiveTabIndex { get; set; }

        public RelayCommand ExitApplicationButton { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Exits application
        /// </summary>
        /// <param name="parameter"></param>
        public void exit(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

        #endregion
    }
}
