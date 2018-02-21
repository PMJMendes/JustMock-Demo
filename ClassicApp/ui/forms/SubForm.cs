using ClassicApp.ui.views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClassicApp.ui.forms
{
    public partial class SubForm : Form, ISubView
    {
        public SubForm()
        {
            InitializeComponent();
        }

        private EventHandler Ok;
        private EventHandler Cancel;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventHandler handler;
            lock (eventLock)
            {
                handler = Cancel;
            }
            handler?.Invoke(sender, e);
        }

        List<string> ISubView.Stuff
        {
            set
            {
                cbxStuff.Items.Clear();
                value.ForEach(i => cbxStuff.Items.Add(i));
            }
        }

        string ISubView.SelectedStuff
        {
            get
            {
                return cbxStuff.SelectedItem.ToString();
            }
            set
            {
                cbxStuff.SelectedItem = value;
            }
        }

        void ISubView.ShowDialog()
        {
            ShowDialog();
        }

        event EventHandler ISubView.Ok
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

        event EventHandler ISubView.Cancel
        {
            add
            {
                lock (eventLock)
                {
                    Cancel += value;
                }
            }
            remove
            {
                lock (eventLock)
                {
                    Cancel -= value;
                }
            }
        }

        void ISubView.Close()
        {
            Close();
        }
    }
}
