using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Ninject;
using System;
using System.Windows.Forms;

namespace ClassicApp.ui.controls
{
    public partial class LookupControl : UserControl, ILookupView
    {
        [Inject]
        public ILookupPresenter presenter
        {
            set
            {
                value.View = this;
            }
        }

        public LookupControl()
        {
            InitializeComponent();
        }

        private EventHandler Search;
        private readonly object eventLock = new object();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            EventHandler handler;
            lock (eventLock)
            {
                handler = Search;
            }
            handler?.Invoke(sender, e);
        }

        string ILookupView.SelectedStuff
        {
            get
            {
                return txtDisplay.Text;
            }
            set
            {
                txtDisplay.Text = value;
            }
        }

        event EventHandler ILookupView.Search
        {
            add
            {
                lock (eventLock)
                {
                    Search += value;
                }
            }
            remove
            {
                lock (eventLock)
                {
                    Search -= value;
                }
            }
        }
    }
}
