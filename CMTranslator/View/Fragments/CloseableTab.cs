using System;
using System.Windows;
using System.Windows.Controls;

namespace CMTranslator.View.Fragments
{
    class CloseableTab : TabItem
    {
        #region Constructors

        /// <summary>
        /// Default constructor, assigns closeable header if isCloseable is true
        /// Otherwise assigns nonCloseableHeader
        /// </summary>
        public CloseableTab(string title, UserControl content)
        {
            CloseableTabHeader closeableHeader = new CloseableTabHeader();
            Header = closeableHeader;
            Title = title;
            Content = content;

            closeableHeader.Button_Close.Click += new RoutedEventHandler(button_close_Click);
            closeableHeader.Label_TabTitle.SizeChanged += new SizeChangedEventHandler(label_TabTitle_SizeChanged);
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when tab close button is pressed
        /// </summary>
        public event TabClosedEventHandler TabClosed;

        #endregion

        #region Properties

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                ((CloseableTabHeader)this.Header).Label_TabTitle.Content = value;
            }
        }


        #endregion

        #region Methods

        /// <summary>
        /// Delegate for tab closed event
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        public delegate void TabClosedEventHandler(Object source, EventArgs e);

        /// <summary>
        /// Raises tab closed event
        /// </summary>
        protected virtual void OnTabClosed()
        {
            if (TabClosed != null)
            {
                TabClosed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Calls OnTabClosed when UI close button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button_close_Click(object sender, RoutedEventArgs e)
        {
            OnTabClosed();
        }

        // Label SizeChanged - When the Size of the Label changes
        // (due to setting the Title) set position of button properly
        public void label_TabTitle_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ((CloseableTabHeader)this.Header).Button_Close.Margin = new Thickness(
                ((CloseableTabHeader)this.Header).Label_TabTitle.ActualWidth + 5, 3, 4, 0);
        }

        #endregion
    }
}
