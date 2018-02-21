using EvalApp.ui.entities;
using EvalApp.ui.forms;
using Ninject;
using Ninject.Activation.Strategies;
using System;
using System.Windows.Forms;

namespace EvalApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new ClassicModule());
            kernel.Components.Add<IActivationStrategy, EvalStrategy>();

            var entry = kernel.Get<MainForm>();
            entry.ShowDialog();
        }
    }
}
