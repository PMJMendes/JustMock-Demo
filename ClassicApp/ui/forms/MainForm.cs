using ClassicApp.ui.views;
using System;
using System.Windows.Forms;

namespace ClassicApp.ui.forms
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private EventHandler Ok;
        private readonly object eventLock = new object();

        private void btnOk_Click(object sender, EventArgs e)
        {
            EventHandler handler;
            lock (eventLock)
            {
                handler = Ok;
            }
            handler?.Invoke(sender, e);
        }

        void IMainView.ShowDialog()
        {
            ShowDialog();
        }

        event EventHandler IMainView.Ok
        {
            add
            {
                lock (eventLock)
                {
                    Ok += value;
                }
            }
            remove
            {
                lock (eventLock)
                {
                    Ok -= value;
                }
            }
        }

        void IMainView.Close()
        {
            Close();
        }
    }
}
