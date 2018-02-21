using EvalApp.services.interfaces;
using EvalApp.ui.entities;
using Ninject;
using System;
using System.Windows.Forms;

namespace EvalApp.ui.forms
{
    public partial class SubForm : Form
    {
        private readonly IDummy dummy;

        [Inject]
        public SubForm(IDummy dummy)
        {
            this.dummy = dummy;

            InitializeComponent();
        }

        public SubModel Model { get; set; }

        private void SubForm_Load(object sender, EventArgs e)
        {
            cbxStuff.Items.Clear();
            dummy.GetStuff().ForEach(i => cbxStuff.Items.Add(i));

            cbxStuff.SelectedItem = Model.Stuff;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Model.Stuff = cbxStuff.SelectedItem.ToString();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
