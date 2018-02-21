using EvalApp.ui.entities;
using EvalApp.ui.forms;
using Ninject;
using System;
using System.Windows.Forms;

namespace EvalApp.ui.controls
{
    public partial class LookupControl : UserControl
    {
        private Func<SubForm> subFormFactory;

        [Inject]
        public Func<SubForm> SubFormFactory
        {
            set
            {
                subFormFactory = value;
            }
        }

        public LookupControl()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var subForm = subFormFactory();
            subForm.Model = new SubModel
            {
                Stuff = txtDisplay.Text
            };

            subForm.ShowDialog();

            txtDisplay.Text = subForm.Model.Stuff;
        }
    }
}
