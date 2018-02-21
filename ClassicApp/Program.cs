using ClassicApp.ui.presenters.interfaces;
using Ninject;
using Ninject.Activation.Strategies;
using System;
using System.Windows.Forms;

namespace ClassicApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IKernel kernel = new StandardKernel(new ClassicModule());
            kernel.Components.Add<IActivationStrategy, ClassicStrategy>();

            var entry = kernel.Get<IMainPresenter>();
            entry.ShowDialog();
        }
    }
}
