using Ninject;
using Ninject.Activation;
using Ninject.Activation.Strategies;
using System.Linq;
using System.Windows.Forms;

namespace ClassicApp
{
    class ClassicStrategy : ActivationStrategy
    {
        private bool activating = false;

        public override void Activate(IContext context, InstanceReference reference)
        {
            reference.IfInstanceIs<UserControl>(uc =>
            {
                if (!activating)
                {
                    activating = true;
                    context.Kernel.InjectDescendantOf(uc);
                    activating = false;
                }
            });
            reference.IfInstanceIs<Form>(form =>
            {
                if (!activating)
                {
                    activating = true;
                    context.Kernel.InjectDescendantOf(form);
                    activating = false;
                }
            });
        }
    }

    static class LocalKernelExtensions
    {
        static public void InjectDescendantOf(this IKernel kernel, ContainerControl containerControl)
        {
            var childrenControls = containerControl.Controls.Cast<Control>();
            foreach (var control in childrenControls)
            {
                InjectUserControlsOf(kernel, control);
            }
        }

        static private void InjectUserControlsOf(this IKernel kernel, Control control)
        {
            kernel.Inject(control);

            var childrenControls = control.Controls.Cast<Control>();
            foreach (var childControl in childrenControls)
            {
                InjectUserControlsOf(kernel, childControl);
            }
        }
    }
}
